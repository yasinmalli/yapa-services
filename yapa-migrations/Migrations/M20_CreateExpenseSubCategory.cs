using FluentMigrator;
using System;

namespace yapa_migrations.Migrations
{
    [Migration(20)]
    public class M20_CreateExpenseSubCategory : Migration
    {
        private const string _tableName = "expense_sub_category";

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("id").AsInt64().Identity().PrimaryKey()                
                .WithColumn("maincategoryid").AsInt64().ForeignKey("FK_sub_category_main_category_id", "expense_main_category", "id")
                .WithColumn("name").AsString(400).NotNullable().Unique()
                .WithColumn("description").AsString(4000);
        }

        public override void Down()
        {
            Delete.Table(_tableName);
        }
    }
}
