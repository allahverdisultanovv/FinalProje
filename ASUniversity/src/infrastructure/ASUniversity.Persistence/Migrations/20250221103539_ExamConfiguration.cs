using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASUniversity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExamConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Groups_GroupId1",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Subjects_SubjectId1",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_GroupId1",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_SubjectId1",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "SubjectId1",
                table: "Exams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId1",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_GroupId1",
                table: "Exams",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SubjectId1",
                table: "Exams",
                column: "SubjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Groups_GroupId1",
                table: "Exams",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Subjects_SubjectId1",
                table: "Exams",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
