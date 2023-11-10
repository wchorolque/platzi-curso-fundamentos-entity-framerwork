using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c01"), null, "Actividades Pendientes", 20 },
                    { new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c02"), null, "Actividades Personales", 40 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { new Guid("3ca96d4d-5b31-4637-a9e6-752395e97f01"), new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c01"), null, new DateTime(2023, 11, 10, 5, 36, 10, 326, DateTimeKind.Local).AddTicks(2880), 1, "Pago de servicios públicos" },
                    { new Guid("3ca96d4d-5b31-4637-a9e6-752395e97f02"), new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c01"), null, new DateTime(2023, 11, 10, 5, 36, 10, 326, DateTimeKind.Local).AddTicks(2893), 0, "Compra de productos" },
                    { new Guid("3ca96d4d-5b31-4637-a9e6-752395e97f03"), new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c02"), null, new DateTime(2023, 11, 10, 5, 36, 10, 326, DateTimeKind.Local).AddTicks(2896), 1, "Terminar de ver series" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3ca96d4d-5b31-4637-a9e6-752395e97f01"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3ca96d4d-5b31-4637-a9e6-752395e97f02"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3ca96d4d-5b31-4637-a9e6-752395e97f03"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c01"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c02"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
