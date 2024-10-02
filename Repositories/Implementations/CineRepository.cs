using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using RepasoParcialCine.Entities;
using RepasoParcialCine.Repositories.Interfaces;
using System.Data;

namespace RepasoParcialCine.Repositories.Implementations
{
    public class CineRepository : ICineRepository
    {
        //si uso EF
        private readonly cineContext _context;
        public CineRepository(cineContext context)
        {
            _context = context;
        }

        public List<Pelicula> GetPeliculas()
        {
            return  _context.Peliculas.Include(p => p.IdGeneroNavigation).Where(p => p.Estreno == true).ToList();
        }
        public List<Pelicula> GetDeletedPeliculas(DateTime desde, DateTime hasta)
        {
            return _context.Peliculas
            .Where(p => p.FechaBaja.HasValue &&
                    p.FechaBaja.Value.Date >= desde.Date &&
                    p.FechaBaja.Value.Date <= hasta.Date)
            .ToList();
        }

        public void AddPelicula(Pelicula pelicula)
        {

            pelicula.Estreno = true;
            _context.Peliculas.Add(pelicula);
        }
        public void UpdatePelicula(int id_pelicula,Pelicula pelicula)
        {
            var peliculaToUpdate = _context.Peliculas.FirstOrDefault(p => p.Id == id_pelicula);

        }
        public Pelicula GetPeliculaById(int id_pelicula)
        {
            return _context.Peliculas.FirstOrDefault(p => p.Id == id_pelicula);
        }

        public void UpdatePelicula(Pelicula pelicula)
        {
            _context.Update(pelicula);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public bool IsValid(Pelicula pelicula)
        {

            return !string.IsNullOrEmpty(pelicula.Director) && !string.IsNullOrEmpty(pelicula.Titulo) && pelicula.Anio > 0 && pelicula.IdGenero > 0;
        }
    }
}
