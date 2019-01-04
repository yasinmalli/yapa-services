using Microsoft.AspNetCore.Mvc;
using System;
using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Controllers
{
    [Route("api/expense")]
    public class ExpenseController : GenericAPIController<Expense>
    {
        private readonly IExpenseRepository _repository;
        public ExpenseController(IExpenseRepository repository): base(repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Expense> GetById([FromRoute] long id)
        {
            var expense = _repository.GetById(id);
            if (expense == null)
                return NotFound();

            return Ok(expense);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Expense resource)
        {
            try
            {
                // todo: do some validation
                var expenseDao = new Expense
                {
                    ExpenseId = Guid.NewGuid(),
                    MainCategoryId = resource.MainCategoryId,
                    SubCategoryId = resource.SubCategoryId,
                    Price = resource.Price,
                    ExpenseType = resource.ExpenseType,
                    SpentAt = resource.SpentAt,
                    Description = resource.Description,
                    Time = DateTime.UtcNow,
                    CreatedOn = DateTime.UtcNow
                };
                _repository.Add(expenseDao);                
            }
            catch (Exception e)
            {
                // todo: log something
                return BadRequest(e);
            }

            return CreatedAtAction("GetById", new { id = resource.Id }, resource);
        }
    }
}
