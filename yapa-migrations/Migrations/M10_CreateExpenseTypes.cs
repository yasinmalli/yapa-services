using FluentMigrator;

namespace yapa_migrations.Migrations
{
    // [Tags("DEV")]
    [Migration(10)]
    public class M10_CreateExpenseTypes : Migration
    {
        private const string _tableName = "ExpenseTypes";

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("TypeId").AsGuid().NotNullable().Unique()
                .WithColumn("Type").AsString(120).NotNullable().Unique()
                .WithColumn("Description").AsString(400);
        }

        public override void Down()
        {
            Delete.Table(_tableName);
        }
    }
}
