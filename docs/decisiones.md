# Decisiones técnicas

| Tema | Decisión |
|---|---|
| Plataforma | Escritorio, solo Windows |
| Lenguaje / UI | C# + WPF, .NET 10 (LTS, soporte hasta nov 2028) |
| Arquitectura | MVVM con CommunityToolkit.Mvvm (Prism descartado por su licenciamiento) |
| Interfaz | WPF UI (Fluent), tema que sigue al de Windows, menú hamburguesa con barra lateral |
| Inyección de dependencias | Generic Host (`Microsoft.Extensions.Hosting`) |
| Estructura | Un solo proyecto con carpetas, más un proyecto de pruebas xUnit |
| Base de datos | SQLite + Entity Framework Core |
| Historial | Paciente con muchos expedientes ordenados por fecha |
| Valores del examen | Texto libre, igual que en el expediente físico |
| Pedido de armazón | Estados: Pendiente → Listo → Entregado, y Cancelado |
| Formulario | Una pantalla con pestañas: Datos, Antecedentes, Examen, Rx, Pedido |
| Datos sensibles | Cifrado solo de identidad y contacto (nombre, domicilio, colonia, ciudad, teléfono) |
| Clave de cifrado | Clave maestra aleatoria protegida por la contraseña, más clave de recuperación impresa |
| Búsqueda | Se descifra en memoria y se filtra |
| Respaldo | Local automático periódico y manual; envío por correo en una fase posterior |
| Pantallas | Inicio de sesión, Home, Nuevo expediente, Detalle del paciente, Configuración |
| Idioma del código | Entidades y UI en español; código técnico en inglés |
