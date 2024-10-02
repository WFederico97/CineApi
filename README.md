# RepasoParcialCine

## Descripci�n
RepasoParcialCine es una soluci�n desarrollada en .NET 6 que gestiona informaci�n sobre pel�culas. Utiliza Entity Framework Core para interactuar con la base de datos y sigue principios de dise�o de software como la inyecci�n de dependencias y el patr�n repositorio.

## Estructura del Proyecto
La soluci�n est� organizada en los siguientes proyectos y carpetas:

- **Controllers**: Contiene los controladores de la API que manejan las solicitudes HTTP.
  - `PeliculaController.cs`: Controlador para gestionar las operaciones relacionadas con las pel�culas.

- **Entities**: Contiene las entidades del dominio que representan las tablas de la base de datos.
  - `Pelicula.cs`: Entidad que representa una pel�cula.
  - `Genero.cs`: Entidad que representa un g�nero de pel�cula.

- **Repositories**: Contiene las interfaces y las implementaciones de los repositorios.
  - `Interfaces/ICineRepository.cs`: Interfaz del repositorio de cine.
  - `Implementations/CineRepository.cs`: Implementaci�n del repositorio de cine.

- **Utils**: Contiene utilidades y helpers que se utilizan en toda la soluci�n.

## Patrones de Dise�o

### Inyecci�n de Dependencias
La inyecci�n de dependencias se utiliza para gestionar las dependencias entre los componentes de la aplicaci�n. Esto se logra a trav�s de la configuraci�n de servicios en el contenedor de dependencias de .NET.

### Patr�n Repositorio
El patr�n repositorio se utiliza para abstraer la l�gica de acceso a datos y proporcionar una interfaz limpia para interactuar con la base de datos. Esto facilita la prueba y el mantenimiento del c�digo.

## Flujo de Trabajo

### Obtener Pel�culas
1. **Solicitud HTTP GET**: El cliente env�a una solicitud HTTP GET a la API para obtener la lista de pel�culas.
2. **Controlador**: `PeliculaController` maneja la solicitud y llama al m�todo `GetPeliculas` del repositorio.
3. **Repositorio**: `CineRepository` obtiene las pel�culas de la base de datos utilizando Entity Framework Core.
4. **Respuesta**: El controlador devuelve la lista de pel�culas al cliente.

### Agregar Nueva Pel�cula
1. **Solicitud HTTP POST**: El cliente env�a una solicitud HTTP POST con los datos de la nueva pel�cula.
2. **Controlador**: `PeliculaController` maneja la solicitud y llama al m�todo `AddPelicula` del repositorio.
3. **Repositorio**: `CineRepository` agrega la nueva pel�cula a la base de datos y guarda los cambios.
4. **Respuesta**: El controlador devuelve una respuesta indicando que la pel�cula se ha creado correctamente.

## Ejemplo de Uso

### Obtener Pel�culas
GET /api/pelicula

### Agregar Nueva Pel�cula
POST /api/pelicula Content-Type: application/json
{ "titulo": "Nueva Pel�cula", "director": "Director Ejemplo", "anio": 2023, "idGenero": 1, "idGeneroNavigation": { "id": 1, "nombre": "Acci�n" } }


## Requisitos
- .NET 6
- Entity Framework Core

## Configuraci�n
1. Clona el repositorio.
2. Configura la cadena de conexi�n a la base de datos en el archivo `appsettings.json`.
3. Ejecuta las migraciones de Entity Framework Core para crear la base de datos.
4. Inicia la aplicaci�n.

## Contribuciones
Las contribuciones son bienvenidas. Por favor, abre un issue o env�a un pull request para discutir cualquier cambio que te gustar�a realizar.

## Licencia
Este proyecto est� licenciado bajo la Licencia MIT. Consulta el archivo `LICENSE` para obtener m�s detalles.## Requisitos
- .NET 6
- Entity Framework Core

## Configuraci�n
1. Clona el repositorio.
2. Configura la cadena de conexi�n a la base de datos en el archivo `appsettings.json`.
3. Ejecuta las migraciones de Entity Framework Core para crear la base de datos.
4. Inicia la aplicaci�n.

## Contribuciones
Las contribuciones son bienvenidas. Por favor, abre un issue o env�a un pull request para discutir cualquier cambio que te gustar�a realizar.

## Licencia
Este proyecto est� licenciado bajo la Licencia MIT. Consulta el archivo `LICENSE` para obtener m�s detalles.
