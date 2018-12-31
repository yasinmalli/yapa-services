using yapa_api.Models;

namespace yapa_api.Contracts
{
    public interface IMainCategoryRepository : IRepository<MainCategory>
    {
        MainCategory SomeCustomMethod();
    }
}
