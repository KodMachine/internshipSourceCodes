using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_kullanici_KullaniciId",
                table: "Log");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kullanici",
                table: "kullanici");

            migrationBuilder.RenameTable(
                name: "kullanici",
                newName: "Kullanici");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kullanici",
                table: "Kullanici",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Kullanici_KullaniciId",
                table: "Log",
                column: "KullaniciId",
                principalTable: "Kullanici",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Kullanici_KullaniciId",
                table: "Log");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kullanici",
                table: "Kullanici");

            migrationBuilder.RenameTable(
                name: "Kullanici",
                newName: "kullanici");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kullanici",
                table: "kullanici",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_kullanici_KullaniciId",
                table: "Log",
                column: "KullaniciId",
                principalTable: "kullanici",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
