using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Kullanici_KullaniciId",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Log_KullaniciId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Log");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Log",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Log_KullaniciId",
                table: "Log",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Kullanici_KullaniciId",
                table: "Log",
                column: "KullaniciId",
                principalTable: "Kullanici",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
