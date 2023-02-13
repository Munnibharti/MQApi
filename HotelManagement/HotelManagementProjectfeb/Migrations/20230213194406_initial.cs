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
                name: "Bills",
                columns: table => new
                {
                    Bill_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stay_dates = table.Column<int>(type: "int", nullable: false),
                    prices = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Bill_id);
                });

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
                    salary = table.Column<double>(type: "float", nullable: false),
                    department_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Receptionist_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.manager_id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Department_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dapartment_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manager_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Department_id);
                    table.ForeignKey(
                        name: "FK_Department_Managers_manager_id",
                        column: x => x.manager_id,
                        principalTable: "Managers",
                        principalColumn: "manager_id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    guest_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Check_out = table.Column<DateTime>(type: "datetime2", nullable: false),
                    check_in = table.Column<DateTime>(type: "datetime2", nullable: false),
                    guest_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reservation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bill_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    manager_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                        name: "FK_Rooms_Managers_manager_id",
                        column: x => x.manager_id,
                        principalTable: "Managers",
                        principalColumn: "manager_id");
                });

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    Receptionist_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    Reservation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Department_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Guest_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bill_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    manager_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.Receptionist_Id);
                    table.ForeignKey(
                        name: "FK_Receptionists_Bills_bill_id",
                        column: x => x.bill_id,
                        principalTable: "Bills",
                        principalColumn: "Bill_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptionists_Department_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Department",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptionists_Managers_manager_id",
                        column: x => x.manager_id,
                        principalTable: "Managers",
                        principalColumn: "manager_id");
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
                    Receptionist_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Guest_id);
                    table.ForeignKey(
                        name: "FK_Guests_Receptionists_Receptionist_Id",
                        column: x => x.Receptionist_Id,
                        principalTable: "Receptionists",
                        principalColumn: "Receptionist_Id");
                    table.ForeignKey(
                        name: "FK_Guests_Rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "room_id");
                });

            migrationBuilder.CreateTable(
                name: "ReceptionistRoom",
                columns: table => new
                {
                    ReceptionistsReceptionist_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionistRoom", x => new { x.ReceptionistsReceptionist_Id, x.room_id });
                    table.ForeignKey(
                        name: "FK_ReceptionistRoom_Receptionists_ReceptionistsReceptionist_Id",
                        column: x => x.ReceptionistsReceptionist_Id,
                        principalTable: "Receptionists",
                        principalColumn: "Receptionist_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceptionistRoom_Rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "room_id",
                        onDelete: ReferentialAction.Cascade);
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
                    Receptionist_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.reservation_id);
                    table.ForeignKey(
                        name: "FK_Reservation_Guests_Guest_Id",
                        column: x => x.Guest_Id,
                        principalTable: "Guests",
                        principalColumn: "Guest_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Receptionists_Receptionist_Id",
                        column: x => x.Receptionist_Id,
                        principalTable: "Receptionists",
                        principalColumn: "Receptionist_Id");
                    table.ForeignKey(
                        name: "FK_Reservation_Rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "room_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_manager_id",
                table: "Department",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_Receptionist_Id",
                table: "Guests",
                column: "Receptionist_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_room_id",
                table: "Guests",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptionistRoom_room_id",
                table: "ReceptionistRoom",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_bill_id",
                table: "Receptionists",
                column: "bill_id");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_Department_Id",
                table: "Receptionists",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_manager_id",
                table: "Receptionists",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Guest_Id",
                table: "Reservation",
                column: "Guest_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Receptionist_Id",
                table: "Reservation",
                column: "Receptionist_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_room_id",
                table: "Reservation",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Bill_id",
                table: "Rooms",
                column: "Bill_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_manager_id",
                table: "Rooms",
                column: "manager_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "ReceptionistRoom");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Receptionists");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
