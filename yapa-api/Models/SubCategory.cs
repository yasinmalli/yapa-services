using Newtonsoft.Json;
using System.Collections.Generic;
using yapa_api.Contracts;

namespace yapa_api.Models
{
    public class SubCategory : IEntity
    {
        public SubCategory()
        {
            Expenses = new HashSet<Expense>();
        }

        public long Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }

        public long MainCategoryId { get; set; }
        public string MainCategoryName { get; set; }

        [JsonIgnore]
        public MainCategory MainCategory { get; set; }
        [JsonIgnore]
        public ICollection<Expense> Expenses { get; set; }
    }
}
