using System;
using yapa_api.Contracts;

namespace yapa_api.Models
{
    public enum ExpenseType
    {
        single,
        reoccuringMonthly,
        reoccuringYearly
    }

    public class Expense : IEntity
    {
        public long Id { get; set; }
        public Guid ExpenseId { get; set; }
        public long MainCategoryId { get; set; }
        public long SubCategoryId { get; set; }
        public double Price { get; set; }
        public ExpenseType ExpenseType { get; set; }        
        public DateTime Time { get; set; }
        public DateTime CreatedOn { get; set; }
        public string SpentAt { get; set; }
        public string Description { get; set; }

        public MainCategory MainCategory { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}