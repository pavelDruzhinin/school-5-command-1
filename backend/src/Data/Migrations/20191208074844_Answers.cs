using Microsoft.EntityFrameworkCore.Migrations;

namespace chatbot.Data.Migrations
{
    public partial class Answers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Answers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ClientId",
                table: "Answers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdentityId",
                table: "Clients",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Clients_ClientId",
                table: "Answers",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Clients_ClientId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Answers_ClientId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Answers");
        }
    }
}
