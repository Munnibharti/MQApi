using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementProjectfeb.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Inventory_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Inventory_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Inventory_Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    manager_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    manager_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.manager_id);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    reservation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    no_of_adults = table.Column<int>(type: "int", nullable: false),
                    no_of_children = table.Column<int>(type: "int", nullable: false),
                    Check_out = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Check_in = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    no_of_nights = table.Column<int>(type: "int", nullable: false),
                    Guest_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Receptionist_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.reservation_id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Bill_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stay_dates = table.Column<int>(type: "int", nullable: false),
                    Room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reservation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Bill_id);
                    table.ForeignKey(
                        name: "FK_Bills_Reservation_Reservation_id",
                        column: x => x.Reservation_id,
                        principalTable: "Reservation",
                        principalColumn: "reservation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Guest_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    E_mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_number = table.Column<long>(type: "bigint", nullable: false),
                    reservation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Guest_id);
                    table.ForeignKey(
                        name: "FK_Guests_Reservation_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "Reservation",
                        principalColumn: "reservation_id");
                });

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    Receptionist_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Receptionist_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    reservation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.Receptionist_Id);
                    table.ForeignKey(
                        name: "FK_Receptionists_Reservation_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "Reservation",
                        principalColumn: "reservation_id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    room_rate = table.Column<double>(type: "float", nullable: false),
                    room_status = table.Column<bool>(type: "bit", nullable: false),
                    Bill_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    reservation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.room_id);
                    table.ForeignKey(
                        name: "FK_Rooms_Bills_Bill_id",
                        column: x => x.Bill_id,
                        principalTable: "Bills",
                        principalColumn: "Bill_id");
                    table.ForeignKey(
                        name: "FK_Rooms_Reservation_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "Reservation",
                        principalColumn: "reservation_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Reservation_id",
                table: "Bills",
                column: "Reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_reservation_id",
                table: "Guests",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_reservation_id",
                table: "Receptionists",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Bill_id",
                table: "Rooms",
                column: "Bill_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_reservation_id",
                table: "Rooms",
                column: "reservation_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Receptionists");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Reservation");
        }
    }
}
