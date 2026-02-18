using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemberManagement.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Branches_BranchID",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "BranchID",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Branches_BranchID",
                table: "Members",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Branches_BranchID1",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Branches_BranchID",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Branches_BranchID1",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "BranchID1",
                table: "Branches");

            migrationBuilder.AlterColumn<int>(
                name: "BranchID",
                table: "Members",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Branches_BranchID",
                table: "Members",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "BranchID");
        }
    }
}
