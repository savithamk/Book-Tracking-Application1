using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Tracking_Application_Migration.Migrations
{
    public partial class BookTrackingApplicationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoryTypes",
                columns: table => new
                {
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryTypes", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    NameToken = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryTypeType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.NameToken);
                    table.ForeignKey(
                        name: "FK_Categories_categoryTypes_CategoryTypeType",
                        column: x => x.CategoryTypeType,
                        principalTable: "categoryTypes",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    NameToken = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryNameToken = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryNameToken",
                        column: x => x.CategoryNameToken,
                        principalTable: "Categories",
                        principalColumn: "NameToken",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryNameToken",
                table: "Books",
                column: "CategoryNameToken");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryTypeType",
                table: "Categories",
                column: "CategoryTypeType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "categoryTypes");
        }
    }
}
