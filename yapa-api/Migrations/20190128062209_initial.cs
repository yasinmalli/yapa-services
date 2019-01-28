using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace yapaapi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "expense_main_category",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(maxLength: 400, nullable: false),
                    description = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expense_main_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "expense_sub_category",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    maincategoryid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expense_sub_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_sub_category_main_category_id",
                        column: x => x.maincategoryid,
                        principalTable: "expense_main_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expenses",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    expenseid = table.Column<Guid>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    expensetype = table.Column<string>(nullable: false),
                    time = table.Column<DateTime>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: false),
                    spentat = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    maincategoryid = table.Column<long>(nullable: false),
                    subcategoryid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses", x => x.id);
                    table.ForeignKey(
                        name: "FK_expenses_main_category_id",
                        column: x => x.maincategoryid,
                        principalTable: "expense_main_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expenses_sub_category_id",
                        column: x => x.subcategoryid,
                        principalTable: "expense_sub_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_expense_sub_category_maincategoryid",
                table: "expense_sub_category",
                column: "maincategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_maincategoryid",
                table: "expenses",
                column: "maincategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_subcategoryid",
                table: "expenses",
                column: "subcategoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expenses");

            migrationBuilder.DropTable(
                name: "expense_sub_category");

            migrationBuilder.DropTable(
                name: "expense_main_category");
        }
    }
}
