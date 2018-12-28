using FluentMigrator;

namespace yapa_migrations.Migrations
{
    // [Tags("DEV")]
    [Migration(10)]
    public class M10_CreateExpenses : Migration
    {
        private const string _tableName = "Expenses";

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsInt64().Identity()
                .WithColumn("Expense_Id").AsGuid();
        }

        public override void Down()
        {
            Delete.Table(_tableName);
        }
    }
}
