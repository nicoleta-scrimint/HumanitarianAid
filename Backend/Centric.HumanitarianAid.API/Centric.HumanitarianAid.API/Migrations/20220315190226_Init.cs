using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanitarianAid.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPlaces = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Address", "Name", "NumberOfPlaces", "OwnerEmail", "OwnerName", "OwnerPhone", "RegistrationDateTime" },
                values: new object[] { new Guid("19fc2719-ce34-4803-80b9-c3adb5dae760"), "Apple Avenue", "Apple", 100, "apple@apple.com", "Mr. Apple", "0712345678", new DateTime(2022, 3, 15, 21, 2, 26, 675, DateTimeKind.Local).AddTicks(7385) });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Address", "Name", "NumberOfPlaces", "OwnerEmail", "OwnerName", "OwnerPhone", "RegistrationDateTime" },
                values: new object[] { new Guid("a177ffd4-e6d5-4a8d-8551-2371f76894c9"), "Cinnamon Avenue", "Cinnamon", 200, "cinnamon@cinnamon.com", "Mr. Cinnamon", "0712345678", new DateTime(2022, 3, 15, 21, 2, 26, 675, DateTimeKind.Local).AddTicks(7423) });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ShelterId",
                table: "Persons",
                column: "ShelterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Shelters");
        }
    }
}
