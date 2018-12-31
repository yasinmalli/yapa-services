using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoryController : ControllerBase //todo: try to use GenericApiController
    {
        private readonly IMainCategoryRepository _repository;
        public MainCategoryController(IMainCategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MainCategory>> GetAllMainCategories()
        {
            return new ObjectResult(_repository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        [HttpGet("{id}")]
        public ActionResult<MainCategory> GetMainCategoryById([FromRoute] long id)
        {
            var mainCategory = _repository.GetById(id);
            if (mainCategory == null)
                return NotFound();

            return Ok(mainCategory);
        }

        [HttpPost]
        public ActionResult AddMainCategory([FromBody] MainCategory mainCategory)
        {
            try
            {
                // todo: do some validation
                _repository.Add(mainCategory);
            }
            catch (Exception e)
            {
                // todo: log something
                return BadRequest();
            }

            return CreatedAtAction("GetMainCategoryById", new { id = mainCategory.Id }, mainCategory);
        }

        private bool MainCategoryExists(long id)
        {
            return _repository.Exists(id);
        }
    }
}