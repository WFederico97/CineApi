# RepasoParcialCine

## Descripción
RepasoParcialCine es una solución desarrollada en .NET 6 que gestiona información sobre películas. Utiliza Entity Framework Core para interactuar con la base de datos y sigue principios de diseño de software como la inyección de dependencias y el patrón repositorio.

## Estructura del Proyecto
La solución está organizada en los siguientes proyectos y carpetas:

- **Controllers**: Contiene los controladores de la API que manejan las solicitudes HTTP.
  - `PeliculaController.cs`: Controlador para gestionar las operaciones relacionadas con las películas.

- **Entities**: Contiene las entidades del dominio que representan las tablas de la base de datos.
  - `Pelicula.cs`: Entidad que representa una película.
  - `Genero.cs`: Entidad que representa un género de película.

- **Repositories**: Contiene las interfaces y las implementaciones de los repositorios.
  - `Interfaces/ICineRepository.cs`: Interfaz del repositorio de cine.
  - `Implementations/CineRepository.cs`: Implementación del repositorio de cine.

- **Utils**: Contiene utilidades y helpers que se utilizan en toda la solución.

## Patrones de Diseño

### Inyección de Dependencias
La inyección de dependencias se utiliza para gestionar las dependencias entre los componentes de la aplicación. Esto se logra a través de la configuración de servicios en el contenedor de dependencias de .NET.

### Patrón Repositorio
El patrón repositorio se utiliza para abstraer la lógica de acceso a datos y proporcionar una interfaz limpia para interactuar con la base de datos. Esto facilita la prueba y el mantenimiento del código.

## Flujo de Trabajo

### Obtener Películas
1. **Solicitud HTTP GET**: El cliente envía una solicitud HTTP GET a la API para obtener la lista de películas.
2. **Controlador**: `PeliculaController` maneja la solicitud y llama al método `GetPeliculas` del repositorio.
3. **Repositorio**: `CineRepository` obtiene las películas de la base de datos utilizando Entity Framework Core.
4. **Respuesta**: El controlador devuelve la lista de películas al cliente.

### Agregar Nueva Película
1. **Solicitud HTTP POST**: El cliente envía una solicitud HTTP POST con los datos de la nueva película.
2. **Controlador**: `PeliculaController` maneja la solicitud y llama al método `AddPelicula` del repositorio.
3. **Repositorio**: `CineRepository` agrega la nueva película a la base de datos y guarda los cambios.
4. **Respuesta**: El controlador devuelve una respuesta indicando que la película se ha creado correctamente.

## Ejemplo de Uso

### Obtener Películas
GET /api/pelicula

### Agregar Nueva Película
POST /api/pelicula Content-Type: application/json
{ "titulo": "Nueva Película", "director": "Director Ejemplo", "anio": 2023, "idGenero": 1, "idGeneroNavigation": { "id": 1, "nombre": "Acción" } }


## Requisitos
- .NET 6
- Entity Framework Core

## Configuración
1. Clona el repositorio.
2. Configura la cadena de conexión a la base de datos en el archivo `appsettings.json`.
3. Ejecuta las migraciones de Entity Framework Core para crear la base de datos.
4. Inicia la aplicación.

## Contribuciones
Las contribuciones son bienvenidas. Por favor, abre un issue o envía un pull request para discutir cualquier cambio que te gustaría realizar.

## Licencia
Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo `LICENSE` para obtener más detalles.## Requisitos
- .NET 6
- Entity Framework Core

## Configuración
1. Clona el repositorio.
2. Configura la cadena de conexión a la base de datos en el archivo `appsettings.json`.
3. Ejecuta las migraciones de Entity Framework Core para crear la base de datos.
4. Inicia la aplicación.

## Contribuciones
Las contribuciones son bienvenidas. Por favor, abre un issue o envía un pull request para discutir cualquier cambio que te gustaría realizar.

## Licencia
Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo `LICENSE` para obtener más detalles.
