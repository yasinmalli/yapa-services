using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using yapa_api.Models;

namespace yapa_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly personalDbContext _context;
        public ValuesController(personalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var mainCategories = _context.MainCategory.Include(c => c.SubCategories);
            //var subCategories = mainCategories.First().SubCategories;

            //var expense = new Expense
            //{
            //    Price = 54.45,
            //    SpentAt = "Yellow Cab",
            //    CreatedOn = DateTime.UtcNow,
            //    Time = DateTime.UtcNow,
            //    Description = "took a cab to somewhere",
            //    ExpenseId = Guid.NewGuid(),
            //    ExpenseType = ExpenseType.single,
            //    MainCategoryId = mainCategories.First().Id,
            //    SubCategoryId = subCategories.First(c => c.Name == "Cab").Id
            //};

            //_context.Add(expense);
            //_context.SaveChanges();

            return new List<string> { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
