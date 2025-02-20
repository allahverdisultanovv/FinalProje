using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASUniversity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId1",
                table: "Students",
                column: "GroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId1",
                table: "Students",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
