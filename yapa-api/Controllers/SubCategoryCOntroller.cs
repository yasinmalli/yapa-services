using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Controllers
{
    [Route("api/subcategory")]
    public class SubCategoryController : GenericAPIController<SubCategory>
    {
        private readonly ISubCategoryRepository _repository;
        public SubCategoryController(ISubCategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubCategory>> GetAllSubCategories([FromQuery] long mainCategoryId)
        {
            var subCategories = _repository.GetAll().Where(c => c.MainCategoryId == mainCategoryId);
            var result = new ObjectResult(subCategories) { StatusCode = (int)HttpStatusCode.OK };

            return result;
        }
    }
}
