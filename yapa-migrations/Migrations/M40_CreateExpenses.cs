using FluentMigrator;

namespace yapa_migrations.Migrations
{
    [Migration(40)]
    public class M40_CreateExpenses : Migration
    {
        private const string _tableName = "Expenses";

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("ExpenseId").AsGuid().NotNullable().Unique()
                .WithColumn("Price").AsDouble().NotNullable()
                .WithColumn("TypeId").AsGuid().ForeignKey("ExpenseTypes", "TypeId")
                .WithColumn("MainCategoryId").AsGuid().ForeignKey("ExpenseMainCategory", "CategoryId")
                .WithColumn("SubCategoryId").AsGuid().ForeignKey("ExpenseSubCategory", "CategoryId")
                .WithColumn("Time").AsDateTime().NotNullable()
                .WithColumn("CreatedOn").AsDateTime()
                .WithColumn("Description").AsString(4000);
        }

        public override void Down()
        {
            Delete.Table(_tableName);
        }
    }
}
