using yapa_api.Models;

namespace yapa_api.Contracts
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        SubCategory SomeCustomMethod();
    }
}
