using FluentMigrator;

namespace yapa_migrations.Migrations
{
    // [Tags("DEV")]
    [Migration(10)]
    public class M10_CreateExpenseMainCategory : Migration
    {
        private const string _tableName = "expense_main_category";

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("id").AsInt64().Identity().PrimaryKey()                
                .WithColumn("name").AsString(400).NotNullable().Unique()
                .WithColumn("description").AsString(4000);
        }

        public override void Down()
        {
            Delete.Table(_tableName);
        }
    }
}
