using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(personalDbContext context): base(context) { }
        
        public SubCategory SomeCustomMethod()
        {
            throw new System.NotImplementedException();
        }
    }
}
