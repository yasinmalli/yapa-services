using FluentMigrator;
using System;

namespace yapa_migrations.Migrations
{
    [Migration(30)]
    public class M30_CreateExpenseSubCategory : Migration
    {
        private const string _tableName = "ExpenseSubCategory";

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("CategoryId").AsGuid().NotNullable().Unique()
                .WithColumn("MainCategoryId").AsGuid().ForeignKey("ExpenseMainCategory", "CategoryId")
                .WithColumn("Name").AsString(400).NotNullable().Unique()
                .WithColumn("Description").AsString(4000);
        }

        public override void Down()
        {
            Delete.Table(_tableName);
        }
    }
}
