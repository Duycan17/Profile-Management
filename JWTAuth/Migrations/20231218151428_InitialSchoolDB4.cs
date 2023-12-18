using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTAuth.Migrations
{
    public partial class InitialSchoolDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Standards_StandardId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "StandardTitle");

            migrationBuilder.DropTable(
                name: "Standards");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_StandardId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "StandardId",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "StandardName",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StandardName",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "StandardId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Standards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandardTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardTitle_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_StandardId",
                table: "Profiles",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardTitle_StandardId",
                table: "StandardTitle",
                column: "StandardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Standards_StandardId",
                table: "Profiles",
                column: "StandardId",
                principalTable: "Standards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
