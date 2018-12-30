using System.Collections.Generic;

namespace yapa_api.Models
{
    public class MainCategory
    {
        public MainCategory()
        {
            SubCategories = new HashSet<SubCategory>();
            Expenses = new HashSet<Expense>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
