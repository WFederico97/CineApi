using Microsoft.AspNetCore.Mvc;
using RepasoParcialCine.Entities;
using RepasoParcialCine.Repositories.Interfaces;

namespace RepasoParcialCine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly ICineRepository _cineRepository;
        public PeliculaController(ICineRepository cineRepository)
        {
            _cineRepository = cineRepository;
        }
        [HttpGet("/peliculas")]
        public IActionResult GetPeliculas()
        {
            try
            {
                var peliculas = _cineRepository.GetPeliculas();
                if (peliculas == null)
                {
                    NotFound("No movies found");
                }
                return Ok(peliculas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something Wrong");
            }
        }
        [HttpGet("/peliculas/eliminadas")]
        public IActionResult GetDeletedPeliculas([FromQuery] DateTime desde, [FromQuery] DateTime hasta)
        {
            try
            {
                var deletedPeliculas = _cineRepository.GetDeletedPeliculas(desde, hasta);
                if(deletedPeliculas == null)
                {
                    NotFound("No deleted movies were found");
                }
                return Ok(deletedPeliculas);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("/peliculas/newPelicula")]
        public IActionResult AddNewPelicula([FromBody] Pelicula pelicula)
        {
            try
            {
                if (pelicula == null)
                {
                    return BadRequest("Invalid movie data");
                }
                pelicula.Id = 0;
                if (!_cineRepository.IsValid(pelicula))
                {
                    return BadRequest("Check the data that you are sending");
                }
                _cineRepository.AddPelicula(pelicula);
                _cineRepository.SaveChanges();

                return CreatedAtAction(nameof(GetPeliculas), new { id = pelicula.Id }, pelicula);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong: {ex.Message}");
            }
        }
        [HttpPut("/peliculas/editarPelicula"), HttpPut("/peliculas/eliminarPelicula")]
        public IActionResult UpdatePelicula([FromQuery]int id_pelicula, [FromBody] Pelicula peliculaToUpdate)
        {
            try
            {
                if(peliculaToUpdate == null)
                {
                    return BadRequest("Invalid movie data.");
                }

                var existingMovie = _cineRepository.GetPeliculaById(id_pelicula);
                if (existingMovie == null)
                {
                    return NotFound($"Movie with the {id_pelicula} not found ");
                }

                if (!string.IsNullOrEmpty(peliculaToUpdate.Titulo) && peliculaToUpdate.Titulo != existingMovie.Titulo)
                {
                    existingMovie.Titulo = peliculaToUpdate.Titulo;
                }

                if (!string.IsNullOrEmpty(peliculaToUpdate.Director) && peliculaToUpdate.Director != existingMovie.Director)
                {
                    existingMovie.Director = peliculaToUpdate.Director;
                }

                if (peliculaToUpdate.Anio != 0 && peliculaToUpdate.Anio != existingMovie.Anio)
                {
                    existingMovie.Anio = peliculaToUpdate.Anio;
                }

                if (peliculaToUpdate.IdGenero != 0 && peliculaToUpdate.IdGenero != existingMovie.IdGenero)
                {
                    existingMovie.IdGenero = peliculaToUpdate.IdGenero;
                }
                if (!string.IsNullOrEmpty(peliculaToUpdate.MotivoBaja) && peliculaToUpdate.MotivoBaja != existingMovie.MotivoBaja)
                {
                    existingMovie.MotivoBaja = peliculaToUpdate.MotivoBaja;
                }
                if (peliculaToUpdate.FechaBaja != null && peliculaToUpdate.FechaBaja != existingMovie.FechaBaja)
                {
                    existingMovie.FechaBaja = peliculaToUpdate.FechaBaja;
                }
                if (peliculaToUpdate.Estreno != true && peliculaToUpdate.Estreno != existingMovie.Estreno)
                {
                    existingMovie.Estreno = peliculaToUpdate.Estreno;
                }

                _cineRepository.UpdatePelicula(existingMovie);
                _cineRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong: {ex.Message}");
            }
        }
    }
}
