using Newtonsoft.Json;
using System.Collections.Generic;
using yapa_api.Contracts;

namespace yapa_api.Models
{
    public class MainCategory : IEntity
    {
        public MainCategory()
        {
            SubCategories = new HashSet<SubCategory>();
            Expenses = new HashSet<Expense>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<SubCategory> SubCategories { get; set; }
        [JsonIgnore]
        public ICollection<Expense> Expenses { get; set; }
    }
}
