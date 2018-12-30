using System.Collections.Generic;

namespace yapa_api.Models
{
    public class SubCategory
    {
        public SubCategory()
        {
            Expenses = new HashSet<Expense>();
        }

        public long Id { get; set; }
        public long MainCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public MainCategory MainCategory { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
