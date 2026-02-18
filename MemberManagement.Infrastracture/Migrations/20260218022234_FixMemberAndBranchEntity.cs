using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemberManagement.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class FixMemberAndBranchEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Branches_BranchID",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "BranchID",
                table: "Members",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_BranchID",
                table: "Members",
                newName: "IX_Members_BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Branches_BranchId",
                table: "Members",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Branches_BranchId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Members",
                newName: "BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_Members_BranchId",
                table: "Members",
                newName: "IX_Members_BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Branches_BranchID",
                table: "Members",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
