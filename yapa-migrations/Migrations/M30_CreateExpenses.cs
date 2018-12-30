using FluentMigrator;

namespace yapa_migrations.Migrations
{
    [Migration(30)]
    public class M30_CreateExpenses : Migration
    {
        private const string _tableName = "expenses";

        public override void Up()
        {
            Create.Table(_tableName)
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("expenseid").AsGuid().NotNullable().Unique()
                .WithColumn("price").AsDouble().NotNullable()
                .WithColumn("expensetype").AsString(400)
                .WithColumn("spentat").AsString(400)
                .WithColumn("description").AsString(4000)
                .WithColumn("maincategoryid").AsInt64().ForeignKey("FK_expenses_main_category_id", "expense_main_category", "id")
                .WithColumn("subcategoryid").AsInt64().ForeignKey("FK_expenses_sub_category_id", "expense_sub_category", "id")
                .WithColumn("time").AsDateTime().NotNullable()
                .WithColumn("createdon").AsDateTime();         
        }

        public override void Down()
        {
            Delete.Table(_tableName);
        }
    }
}
