using IMDBApplication.DataContext;
using IMDBApplication.DataContext.Repository;
using IMDBApplication.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddActor(Actor actor)
        {
            var addedActor = await _unitOfWork.ActorRepository.Add(actor);
            _unitOfWork.Complete();
            return Ok(addedActor);
        }

        [HttpGet]
        public async Task<IActionResult> GetActors()
        {
            var actorList = await _unitOfWork.ActorRepository.GetAll();
            return Ok(actorList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(int id)
        {
            var existingActor = await _unitOfWork.ActorRepository.GetById(id);
            return Ok(existingActor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actor = await _unitOfWork.ActorRepository.GetById(id);
            _unitOfWork.ActorRepository.Remove(actor);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateActor([FromBody] Actor actor)
        {
            _unitOfWork.ActorRepository.Update(actor);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
