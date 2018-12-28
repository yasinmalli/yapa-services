using FluentMigrator;

namespace yapa_migrations.Migrations
{
    // [Tags("DEV")]
    [Migration(20)]
    public class M20_CreateTest : Migration
    {
        private const string _tableName = "Test";

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
