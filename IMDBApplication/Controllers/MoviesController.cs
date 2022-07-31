using IMDBApplication.DataContext;
using IMDBApplication.DTO;
using IMDBApplication.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromForm] MovieUploadDTO movieUploadDTO)
        {
            List<ActorMovie> actorList = JsonConvert.DeserializeObject<List<ActorMovie>>(movieUploadDTO.ActorMovie);
            var supportedTypes = new[] { "JPEG", "GIF", "PNG", "JPG"};
            var fileExt = System.IO.Path.GetExtension(movieUploadDTO.file.FileName).Substring(1).ToUpper();
            if (supportedTypes.Contains(fileExt))
            {
                var movie = new Movie();
                if (movieUploadDTO.file.Length > 0)
                {
                    using (var target = new MemoryStream())
                    {
                        movieUploadDTO.file.CopyTo(target);
                        movie.Poster = target.ToArray();
                    }
                }
                movie.MovieName = movieUploadDTO.MovieName;
                movie.Plot = movieUploadDTO.Plot;
                movie.ProducerId = movieUploadDTO.ProducerId;
                movie.DateOfRelease = movieUploadDTO.DateOfRelease;
                movie.ActorMovie = actorList;
                await _unitOfWork.MovieRepository.Add(movie);
                _unitOfWork.Complete();
            }
            else
            {
                var errorMessage = "File Extension Is InValid";
                return Ok(errorMessage);
            }
            return Ok();
        }

        [HttpGet]
        public  IActionResult GetMovies()
        {
            var movieList =  _unitOfWork.MovieRepository.GetMoviesBasedOnActorAndProducer();
            return Ok(movieList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _unitOfWork.MovieRepository.GetById(id);
            _unitOfWork.MovieRepository.Remove(movie);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMovie([FromForm] MovieUploadDTO movieUploadDTO)
        {
            List<ActorMovie> actorList = JsonConvert.DeserializeObject<List<ActorMovie>>(movieUploadDTO.ActorMovie);
            var supportedTypes = new[] { "JPEG", "GIF", "PNG", "JPG" };
            var fileExt = System.IO.Path.GetExtension(movieUploadDTO.file.FileName).Substring(1).ToUpper();
            if (supportedTypes.Contains(fileExt))
            {
                var allActorList = _unitOfWork.ActorMovieRepository.GetAll().Result;
                var filterActorList = allActorList.Where(t => t.MovieId == movieUploadDTO.Id).ToList();
                _unitOfWork.ActorMovieRepository.RemoveRange(filterActorList);
                var existingMovie = _unitOfWork.MovieRepository.GetById(movieUploadDTO.Id).Result;
                if (movieUploadDTO.file.Length > 0)
                {
                    using (var target = new MemoryStream())
                    {
                        movieUploadDTO.file.CopyTo(target);
                        existingMovie.Poster = target.ToArray();
                    }
                }
                existingMovie.Id = movieUploadDTO.Id;
                existingMovie.MovieName = movieUploadDTO.MovieName;
                existingMovie.Plot = movieUploadDTO.Plot;
                existingMovie.ProducerId = movieUploadDTO.ProducerId;
                existingMovie.DateOfRelease = movieUploadDTO.DateOfRelease;
                existingMovie.ActorMovie = actorList;
                _unitOfWork.MovieRepository.Update(existingMovie);
                _unitOfWork.Complete();
            }
            else
            {
                var errorMessage = "File Extension Is InValid";
                return Ok(errorMessage);
            }
            return Ok();
        }

    }
}
