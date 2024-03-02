using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataRepositories.Migrations
{
    /// <inheritdoc />
    public partial class AddArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockKeepingUnit = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name", "Price", "StockKeepingUnit" },
                values: new object[,]
                {
                    { 1, "Excavator", 449.99m, "LEGO-42100" },
                    { 2, "Lamborghini Sián", 399.99m, "LEGO-42115" },
                    { 3, "Millennium Falcon", 849.99m, "LEGO-75192" },
                    { 4, "Verkenningsrover op Mars", 149.99m, "LEGO-42180" },
                    { 5, "Concorde", 119.99m, "LEGO-10318" },
                    { 6, "Treinrails", 19.99m, "LEGO-60205" },
                    { 7, "Wissels", 19.99m, "LEGO-60238" },
                    { 8, "Passagierssneltrein", 159.99m, "LEGO-60337" },
                    { 9, "Titanic", 679.99m, "LEGO-10294" },
                    { 10, "Lego Minifiguren serie", 3.99m, "LEGO-71045" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
