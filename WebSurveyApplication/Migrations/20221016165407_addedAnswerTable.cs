using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSurveyApplication.Migrations
{
    public partial class addedAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyTableModel_SurveyModels_SurveyModelid",
                table: "SurveyTableModel");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyModelid",
                table: "SurveyTableModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AnswerModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyModelId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerModels", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyTableModel_SurveyModels_SurveyModelid",
                table: "SurveyTableModel",
                column: "SurveyModelid",
                principalTable: "SurveyModels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyTableModel_SurveyModels_SurveyModelid",
                table: "SurveyTableModel");

            migrationBuilder.DropTable(
                name: "AnswerModels");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyModelid",
                table: "SurveyTableModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyTableModel_SurveyModels_SurveyModelid",
                table: "SurveyTableModel",
                column: "SurveyModelid",
                principalTable: "SurveyModels",
                principalColumn: "id");
        }
    }
}
