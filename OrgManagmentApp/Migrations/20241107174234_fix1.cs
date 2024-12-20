using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrgManagmentApp.Migrations
{
    /// <inheritdoc />
    public partial class fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Базовый уровень доступа", "Базовый" },
                    { 2, "Премиум уровень доступа", "Премиум" },
                    { 3, "VIP уровень доступа", "VIP" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Администратор системы", "Administrator" },
                    { 2, "Обычный пользователь", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "FirstName", "LastName", "Login", "MiddleName", "PasswordHash", "PhoneNumber", "RoleID" },
                values: new object[] { 1, "admin@example.com", "Admin", "Adminov", "admin", "yo", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", null, 1 });
        }
    }
}
