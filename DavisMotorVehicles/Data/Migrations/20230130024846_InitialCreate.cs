using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DavisMotorVehicles.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TireStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfTires = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    VinNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    FuelLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    TireStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tires_TireStatuses_TireStatusId",
                        column: x => x.TireStatusId,
                        principalTable: "TireStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tires_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TireStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Bad" },
                    { 2, "Fair" },
                    { 3, "Good" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Name", "NumberOfTires" },
                values: new object[,]
                {
                    { 1, "Car", 4 },
                    { 2, "Truck", 4 },
                    { 3, "Motorcycle", 2 },
                    { 4, "Boat", 0 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "FuelLevel", "IsActive", "Make", "Model", "VehicleTypeId", "VinNumber", "Year" },
                values: new object[,]
                {
                    { 1, 40, true, "Dodge", "Avenger", 1, "1C3CDZBG8DN504146", 2013 },
                    { 2, 50, true, "Honda", "CRV", 1, "5J6RM4850CL703159", 2017 },
                    { 3, 60, true, "Acura", "Integra", 1, "JH4KA3151LC012001", 2018 },
                    { 4, 70, true, "Dodge", "Ram1500", 2, "3B7KF23Z42M211215", 2011 },
                    { 5, 80, true, "Tige", "WakeMaster", 4, "848DKDIEKDL888DKD", 2003 },
                    { 6, 90, true, "Honda", "Shadow", 3, "KDEID3366DKDKDKIF", 2022 }
                });

            migrationBuilder.InsertData(
                table: "Tires",
                columns: new[] { "Id", "IsActive", "TireStatusId", "VehicleId" },
                values: new object[,]
                {
                    { 1, true, 1, 1 },
                    { 2, true, 1, 1 },
                    { 3, true, 1, 1 },
                    { 4, true, 1, 1 },
                    { 5, true, 3, 2 },
                    { 6, true, 3, 2 },
                    { 7, true, 3, 2 },
                    { 8, true, 3, 2 },
                    { 9, true, 1, 3 },
                    { 10, true, 1, 3 },
                    { 11, true, 1, 3 },
                    { 12, true, 1, 3 },
                    { 13, true, 2, 4 },
                    { 14, true, 2, 4 },
                    { 15, true, 2, 4 },
                    { 16, true, 2, 4 },
                    { 17, true, 2, 6 },
                    { 18, true, 2, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tires_TireStatusId",
                table: "Tires",
                column: "TireStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tires_VehicleId",
                table: "Tires",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tires");

            migrationBuilder.DropTable(
                name: "TireStatuses");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
