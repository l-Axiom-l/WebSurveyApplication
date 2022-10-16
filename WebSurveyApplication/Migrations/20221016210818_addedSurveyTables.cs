using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSurveyApplication.Migrations
{
    public partial class addedSurveyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyModelId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerModels", x => x.id);
                });

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
                    SurveyModelid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTableModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_SurveyTableModel_SurveyModels_SurveyModelid",
                        column: x => x.SurveyModelid,
                        principalTable: "SurveyModels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyTableModel_SurveyModelid",
                table: "SurveyTableModel",
                column: "SurveyModelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerModels");

            migrationBuilder.DropTable(
                name: "SurveyTableModel");

            migrationBuilder.DropTable(
                name: "SurveyModels");
        }
    }
}
