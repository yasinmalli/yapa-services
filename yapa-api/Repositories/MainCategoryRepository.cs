using System.Collections.Generic;
using System.Linq;
using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Repositories
{
    public class MainCategoryRepository : Repository<MainCategory>, IMainCategoryRepository
    {
        private readonly personalDbContext _context;
        public MainCategoryRepository(personalDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SubCategory> GetSubCategories(long mainCategoryId)
        {
            return _context.Set<SubCategory>()
                        .Where(c => c.MainCategoryId == mainCategoryId).ToList();
        }        
    }
}
