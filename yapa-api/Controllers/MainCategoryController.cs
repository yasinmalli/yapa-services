using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Controllers
{
    [Route("api/maincategory")]
    public class MainCategoryController : GenericAPIController<MainCategory>
    {
        private readonly IMainCategoryRepository _repository;
        public MainCategoryController(IMainCategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual ActionResult<IEnumerable<MainCategory>> GetAll()
        {
            var result = new ObjectResult(_repository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };            

            return result;
        }
    }
}