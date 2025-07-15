using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YogaSix.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChallengeLevels",
                columns: table => new
                {
                    ChallengeLevelId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeLevels", x => x.ChallengeLevelId);
                });

            migrationBuilder.CreateTable(
                name: "YogaClasses",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: false),
                    ChallengeLevelId = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YogaClasses", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_YogaClasses_ChallengeLevels_ChallengeLevelId",
                        column: x => x.ChallengeLevelId,
                        principalTable: "ChallengeLevels",
                        principalColumn: "ChallengeLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChallengeLevels",
                columns: new[] { "ChallengeLevelId", "Name" },
                values: new object[,]
                {
                    { "A", "Advanced" },
                    { "B", "Beginner" },
                    { "I", "Intermediate" }
                });

            migrationBuilder.InsertData(
                table: "YogaClasses",
                columns: new[] { "ClassId", "ChallengeLevelId", "Description", "Name", "Size" },
                values: new object[,]
                {
                    { 1, "B", "Gentle morning session", "Sunrise Flow", 20 },
                    { 2, "A", "Intense strength-building session", "Power Yoga", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_YogaClasses_ChallengeLevelId",
                table: "YogaClasses",
                column: "ChallengeLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YogaClasses");

            migrationBuilder.DropTable(
                name: "ChallengeLevels");
        }
    }
}
