using FluentMigrator;

namespace yapa_migrations.Migrations
{
    // [Tags("DEV")]
    [Migration(20)]
    public class M20_CreateExpenseMainCategory : Migration
    {
        private const string _tableName = "ExpenseMainCategory";

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("CategoryId").AsGuid().NotNullable().Unique()
                .WithColumn("Name").AsString(400).NotNullable().Unique()
                .WithColumn("Description").AsString(4000);
        }

        public override void Down()
        {
            Delete.Table(_tableName);
        }
    }
}
