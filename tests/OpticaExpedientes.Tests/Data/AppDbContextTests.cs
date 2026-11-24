using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OpticaExpedientes.Data;
using OpticaExpedientes.Models;

namespace OpticaExpedientes.Tests.Data;

public sealed class AppDbContextTests : IDisposable
{
  private readonly SqliteConnection _connection;
  private readonly DbContextOptions<AppDbContext> _options;

  public AppDbContextTests()
  {
    _connection = new SqliteConnection("Data Source=:memory:");
    _connection.Open();

    _options = new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlite(_connection)
        .Options;

    using var context = new AppDbContext(_options);
    context.Database.EnsureCreated();
  }

  public void Dispose() => _connection.Dispose();

  private AppDbContext NewContext() => new(_options);

  private static Expediente NewExpediente(Paciente paciente, int folio) => new()
  {
    Paciente = paciente,
    Folio = folio,
    Fecha = DateOnly.FromDateTime(DateTime.Today),
  };

  [Fact]
  public async Task Can_save_and_reload_paciente_with_expediente_and_pedido()
  {
    var paciente = new Paciente { Nombre = "Paciente de prueba" };
    var expediente = NewExpediente(paciente, 1);
    expediente.AvOD = "20/20";
    expediente.Pedido = new PedidoArmazon
    {
      FechaPedido = DateOnly.FromDateTime(DateTime.Today),
      Total = 1500m,
    };

    await using (var context = NewContext())
    {
      context.Add(expediente);
      await context.SaveChangesAsync();
    }

    await using var readContext = NewContext();
    var loaded = await readContext.Expedientes
        .Include(e => e.Paciente)
        .Include(e => e.Pedido)
        .SingleAsync();

    Assert.Equal("Paciente de prueba", loaded.Paciente.Nombre);
    Assert.Equal("20/20", loaded.AvOD);
    Assert.Equal(EstadoPedido.Pendiente, loaded.Pedido!.Estado);
    Assert.Equal(1500m, loaded.Pedido.Total);
  }

  [Fact]
  public async Task Folio_must_be_unique()
  {
    var paciente = new Paciente { Nombre = "Paciente de prueba" };

    await using var context = NewContext();
    context.Add(NewExpediente(paciente, 1));
    context.Add(NewExpediente(paciente, 1));

    await Assert.ThrowsAsync<DbUpdateException>(() => context.SaveChangesAsync());
  }

  [Fact]
  public async Task Expediente_can_only_have_one_pedido()
  {
    var paciente = new Paciente { Nombre = "Paciente de prueba" };
    var expediente = NewExpediente(paciente, 1);
    expediente.Pedido = new PedidoArmazon { FechaPedido = DateOnly.FromDateTime(DateTime.Today) };

    await using (var setupContext = NewContext())
    {
      setupContext.Add(expediente);
      await setupContext.SaveChangesAsync();
    }

    // Contexto nuevo: EF no tiene el expediente cargado, así que el conflicto
    // lo detecta el índice único de la base de datos.
    await using var context = NewContext();
    context.Add(new PedidoArmazon
    {
      ExpedienteId = expediente.Id,
      FechaPedido = DateOnly.FromDateTime(DateTime.Today),
    });

    await Assert.ThrowsAsync<DbUpdateException>(() => context.SaveChangesAsync());
  }

  [Fact]
  public async Task Deleting_records_is_not_allowed()
  {
    await using var context = NewContext();
    var paciente = new Paciente { Nombre = "Paciente de prueba" };
    context.Add(paciente);
    await context.SaveChangesAsync();

    context.Remove(paciente);

    await Assert.ThrowsAsync<InvalidOperationException>(() => context.SaveChangesAsync());
  }

  [Fact]
  public async Task Timestamps_are_set_on_create_and_update()
  {
    await using var context = NewContext();
    var paciente = new Paciente { Nombre = "Paciente de prueba" };
    context.Add(paciente);
    await context.SaveChangesAsync();

    var createdAt = paciente.CreadoEn;
    Assert.NotEqual(default, createdAt);
    Assert.Equal(createdAt, paciente.ActualizadoEn);

    await Task.Delay(20);
    paciente.Ocupacion = "Estudiante";
    await context.SaveChangesAsync();

    Assert.Equal(createdAt, paciente.CreadoEn);
    Assert.True(paciente.ActualizadoEn > createdAt);
  }
}
