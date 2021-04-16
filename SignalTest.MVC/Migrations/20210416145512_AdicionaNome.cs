using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalTest.MVC.Migrations
{
    public partial class AdicionaNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "UserInstances",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "UserInstances");
        }
    }
}
