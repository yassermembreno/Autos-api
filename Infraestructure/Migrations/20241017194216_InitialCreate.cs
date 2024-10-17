using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marcaAutosDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    marca = table.Column<string>(type: "text", nullable: false),
                    pais = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcaAutosDb", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "marcaAutosDb",
                columns: new[] { "Id", "marca", "pais", "url" },
                values: new object[,]
                {
                    { new Guid("706ba802-3444-44eb-a39a-404d4a709245"), "Ford", "Estados Unidos", "https://www.ford.com/" },
                    { new Guid("7b09e72d-755b-40a1-80e0-8e0c847ece0e"), "Subaru", "Japon", "https://www.worldsubaru.com/" },
                    { new Guid("b7b6b47c-ec42-4f4c-871f-fd3330e919f5"), "BMW", "Alemania", "https://www.bmw.com/en/index.html" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "marcaAutosDb");
        }
    }
}
