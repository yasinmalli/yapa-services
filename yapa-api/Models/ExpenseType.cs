using System;

namespace yapa_api.Models
{
    public partial class ExpenseType
    {
        public int Id { get; set; }
        public Guid TypeId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
