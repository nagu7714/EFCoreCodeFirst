using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCodeFirstSample.Migrations
{
    public partial class SchoolDBV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressOfStudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Students_AddressOfStudentId",
                        column: x => x.AddressOfStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_AddressOfStudentId",
                table: "StudentAddresses",
                column: "AddressOfStudentId",
                unique: true,
                filter: "[AddressOfStudentId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAddresses");
        }
    }
}
