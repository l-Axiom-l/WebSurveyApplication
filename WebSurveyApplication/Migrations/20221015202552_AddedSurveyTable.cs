using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSurveyApplication.Migrations
{
    public partial class AddedSurveyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyModels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyTableModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyModelid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTableModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_SurveyTableModel_SurveyModels_SurveyModelid",
                        column: x => x.SurveyModelid,
                        principalTable: "SurveyModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyTableModel_SurveyModelid",
                table: "SurveyTableModel",
                column: "SurveyModelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyTableModel");

            migrationBuilder.DropTable(
                name: "SurveyModels");
        }
    }
}
