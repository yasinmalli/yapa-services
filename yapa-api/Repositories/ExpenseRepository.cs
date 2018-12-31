using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {        
        public ExpenseRepository(personalDbContext context): base(context) { }

        public Expense SomeCustomMethod()
        {
            throw new System.NotImplementedException();
        }
    }
}
