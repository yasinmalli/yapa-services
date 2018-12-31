using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoryController : ControllerBase
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

        private bool MainCategoryExists(long id)
        {
            return _repository.Exists(id);
        }
    }
}