using yapa_api.Contracts;
using yapa_api.Models;

namespace yapa_api.Controllers
{
    public class MainCategoryController : GenericAPIController<MainCategory>
    {
        public MainCategoryController(IMainCategoryRepository repository) : base(repository) { }        
    }
}