using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using yapa_api.Contracts;

namespace yapa_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericAPIController<T> : ControllerBase where T: class, IEntity
    {
        private readonly IRepository<T> _repository;
        public GenericAPIController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public virtual ActionResult<T> GetById([FromRoute] long id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpGet]
        public virtual ActionResult<IEnumerable<T>> GetAll()
        {
            return new ObjectResult(_repository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        [HttpPost]
        public virtual ActionResult Add([FromBody] T entity)
        {
            try
            {
                // todo: do some validation
                _repository.Add(entity);
            }
            catch (Exception e)
            {
                // todo: log something
                return BadRequest();
            }

            return CreatedAtAction("GetById", new { id = entity.Id }, entity);
        }
    }
}
