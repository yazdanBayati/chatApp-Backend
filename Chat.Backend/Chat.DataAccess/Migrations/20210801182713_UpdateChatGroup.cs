using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.DataAccess.Migrations
{
    public partial class UpdateChatGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ChatGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ChatGroups",
                type: "NVARCHAR(50)",
                nullable: true);
        }
    }
}
