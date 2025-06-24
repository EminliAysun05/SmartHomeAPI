using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHomeAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingSeedDatasTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeviceCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DeviceCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeviceCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "DeviceCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 4, "Sensor devices", "Sensor" },
                    { 5, "Devices that act on data", "Actuator" },
                    { 6, "Security and monitoring devices", "Camera" }
                });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "HealthStatus", "IsOnline", "LocationId", "Name", "PowerUsage" },
                values: new object[] { 4, "Healthy", true, 4, "Temperature Sensor", 2.5 });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "HealthStatus", "IsOnline", "LocationId", "Name", "PowerUsage" },
                values: new object[] { 4, "Warning", false, 5, "Motion Sensor", 1.2 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Floor", "Name", "RoomType" },
                values: new object[] { 1, "Living Room", "Common" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Floor", "Name", "RoomType" },
                values: new object[,]
                {
                    { 5, 1, "Kitchen", "Food" },
                    { 6, 2, "Bedroom", "Private" },
                    { 7, 0, "Garage", "Storage" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "CategoryId", "HealthStatus", "IsOnline", "LocationId", "Name", "PowerUsage" },
                values: new object[,]
                {
                    { 6, 5, "Healthy", true, 4, "Smart Light", 3.0 },
                    { 7, 5, "Critical", false, 6, "Smart Plug", 0.5 },
                    { 8, 6, "Healthy", true, 7, "Security Camera", 4.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeviceCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DeviceCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DeviceCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "DeviceCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Sensor devices", "Sensor" },
                    { 2, "Devices that act on data", "Actuator" },
                    { 3, "Security and monitoring devices", "Camera" }
                });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "HealthStatus", "IsOnline", "LocationId", "Name", "PowerUsage" },
                values: new object[] { 2, "Critical", false, 3, "Smart Plug", 0.5 });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "HealthStatus", "IsOnline", "LocationId", "Name", "PowerUsage" },
                values: new object[] { 3, "Healthy", true, 4, "Security Camera", 4.0 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Floor", "Name", "RoomType" },
                values: new object[] { 0, "Garage", "Storage" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Floor", "Name", "RoomType" },
                values: new object[,]
                {
                    { 1, 1, "Living Room", "Common" },
                    { 2, 1, "Kitchen", "Food" },
                    { 3, 2, "Bedroom", "Private" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "CategoryId", "HealthStatus", "IsOnline", "LocationId", "Name", "PowerUsage" },
                values: new object[,]
                {
                    { 1, 1, "Healthy", true, 1, "Temperature Sensor", 2.5 },
                    { 2, 1, "Warning", false, 2, "Motion Sensor", 1.2 },
                    { 3, 2, "Healthy", true, 1, "Smart Light", 3.0 }
                });
        }
    }
}
