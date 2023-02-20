using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementProjectfeb.Migrations
{
    public partial class deletecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
