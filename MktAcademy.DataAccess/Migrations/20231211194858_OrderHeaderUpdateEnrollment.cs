using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MktAcademy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrderHeaderUpdateEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseEnrollment",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseEnrollment",
                table: "OrderHeaders");
        }
    }
}
