﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementProjectfeb.Migrations
{
    public partial class DeleteColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Receptionists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
