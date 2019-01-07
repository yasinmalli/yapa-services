using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        private readonly personalDbContext _context;
        public ExpenseRepository(personalDbContext context): base(context)
        {
            _context = context;
        }

        public IEnumerable<Expense> GetExpensesWithCategories()
        {
            return _context.Set<Expense>()
                        .Include(e => e.MainCategory)
                        .Include(e => e.SubCategory)
                        .OrderByDescending(e => e.Time);
        }
    }
}
