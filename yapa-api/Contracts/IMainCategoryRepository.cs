using System.Collections.Generic;
using yapa_api.Models;

namespace yapa_api.Contracts
{
    public interface IMainCategoryRepository : IRepository<MainCategory>
    {
        IEnumerable<SubCategory> GetSubCategories(long mainCategoryId);
    }
}
