using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalTest.MVC.Migrations
{
    public partial class Adiciona_entidade_tweet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInstances");

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_UserId",
                table: "Tweets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.CreateTable(
                name: "UserInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VistoPorUltimo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstances", x => x.Id);
                });
        }
    }
}
