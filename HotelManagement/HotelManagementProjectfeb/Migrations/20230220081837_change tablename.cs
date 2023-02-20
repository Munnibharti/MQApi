using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementProjectfeb.Migrations
{
    public partial class changetablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
          migrationBuilder.RenameTable(
                name: "Users",
                newName: "Staffs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
