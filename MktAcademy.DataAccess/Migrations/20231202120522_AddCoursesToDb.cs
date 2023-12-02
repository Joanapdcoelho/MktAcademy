using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MktAcademy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCoursesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price20 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "ListPrice", "Name", "Price20", "Remarks" },
                values: new object[,]
                {
                    { 1, "Marketing course 25h", 540m, "Marketing", 432m, "" },
                    { 2, "Marketing course 25h", 540m, "Digital Marketing", 432m, "" },
                    { 3, "Marketing course 25h", 540m, "E-mail Marketing", 432m, "" },
                    { 4, "Marketing course 25h", 540m, "Social Media Marketing", 432m, "" },
                    { 5, "Marketing course 25h", 540m, "Legislation 2.0", 432m, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
