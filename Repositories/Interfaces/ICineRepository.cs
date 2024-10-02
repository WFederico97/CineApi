using RepasoParcialCine.Entities;

namespace RepasoParcialCine.Repositories.Interfaces
{
    public interface ICineRepository
    {
        //solo peliculas en estreno
        List<Pelicula> GetPeliculas();
        List<Pelicula> GetDeletedPeliculas(DateTime desde, DateTime hasta);
        Pelicula GetPeliculaById(int id_pelicula);
        void AddPelicula(Pelicula pelicula);
        void SaveChanges();
        void UpdatePelicula(Pelicula pelicula);
        bool IsValid(Pelicula pelicula);
    }
}
