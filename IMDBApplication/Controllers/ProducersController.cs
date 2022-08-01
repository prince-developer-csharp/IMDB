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
    public class ProducersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProducersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddProducer(Producer producer)
        {
            var addedProducer = await _unitOfWork.ProducerRepository.Add(producer);
            _unitOfWork.Complete();
            return Ok(addedProducer);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducers()
        {
            var producersList = await _unitOfWork.ProducerRepository.GetAll();
            return Ok(producersList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducerById(int id)
        {
            var existingProducer = await _unitOfWork.ProducerRepository.GetById(id);
            if (existingProducer == null)
            {
                return NotFound();
            }
            return Ok(existingProducer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            var producer = await _unitOfWork.ProducerRepository.GetById(id);
            if(producer == null)
            {
                return NotFound();
            }
            _unitOfWork.ProducerRepository.Remove(producer);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProducer([FromBody] Producer producer)
        {
            var existingProducer = _unitOfWork.ProducerRepository.GetById(producer.Id).Result;
            if(existingProducer == null)
            {
                return NotFound();
            }
            _unitOfWork.ProducerRepository.Update(producer);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
