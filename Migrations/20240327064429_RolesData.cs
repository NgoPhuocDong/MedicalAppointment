using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalAppointment.Migrations
{
    /// <inheritdoc />
    public partial class RolesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a14d2b0b-7d08-464b-a491-ee1d72e7d41c", null, "Admin", "ADMIN" },
                    { "3657dd42-a440-4e49-9a51-02f770d790d4", null, "Doctor", "DOCTOR" },
                    { "fab42eb6-0da3-44c7-afb3-93ef176eb5a2", null, "Patients", "PATIENTS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a14d2b0b-7d08-464b-a491-ee1d72e7d41c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3657dd42-a440-4e49-9a51-02f770d790d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab42eb6-0da3-44c7-afb3-93ef176eb5a2");
        }
    }
}
