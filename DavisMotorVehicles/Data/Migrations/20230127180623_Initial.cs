using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DavisMotorVehicles.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Name = table.Column<string>(type: "TEXT", nullable: false)
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
                    { 2, "Ok" },
                    { 3, "Good" },
                    { 4, "Great" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Car" },
                    { 2, "Truck" },
                    { 3, "Motorcycle" },
                    { 4, "Boat" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "FuelLevel", "Make", "Model", "VehicleTypeId", "VinNumber", "Year" },
                values: new object[,]
                {
                    { 1, 40, "Dodge", "Avenger", 1, "1C3CDZBG8DN504146", 2013 },
                    { 2, 50, "Honda", "CRV", 1, "5J6RM4850CL703159", 2017 },
                    { 3, 60, "Acura", "Integra", 1, "JH4KA3151LC012001", 2018 },
                    { 4, 70, "Dodge", "Ram1500", 2, "3B7KF23Z42M211215", 2011 },
                    { 5, 80, "Tige", "WakeMaster", 4, "848DKDIEKDL888DKD", 2003 },
                    { 6, 90, "Honda", "Shadow", 3, "KDEID3366DKDKDKIF", 2022 }
                });

            migrationBuilder.InsertData(
                table: "Tires",
                columns: new[] { "Id", "TireStatusId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 3, 1 },
                    { 3, 3, 1 },
                    { 4, 3, 1 },
                    { 5, 4, 2 },
                    { 6, 4, 2 },
                    { 7, 4, 2 },
                    { 8, 4, 2 },
                    { 9, 1, 3 },
                    { 10, 1, 3 },
                    { 11, 1, 3 },
                    { 12, 1, 3 },
                    { 13, 4, 4 },
                    { 14, 4, 4 },
                    { 15, 4, 4 },
                    { 16, 4, 4 },
                    { 17, 4, 6 },
                    { 18, 4, 6 }
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
