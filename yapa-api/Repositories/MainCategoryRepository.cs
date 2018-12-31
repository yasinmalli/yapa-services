using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Repositories
{
    public class MainCategoryRepository : Repository<MainCategory>, IMainCategoryRepository
    {
        public MainCategoryRepository(personalDbContext context) : base(context) { }

        public MainCategory SomeCustomMethod()
        {
            throw new System.NotImplementedException();
        }
    }
}
