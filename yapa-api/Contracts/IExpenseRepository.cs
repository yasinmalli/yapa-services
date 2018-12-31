using yapa_api.Models;

namespace yapa_api.Contracts
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Expense SomeCustomMethod();
    }
}
