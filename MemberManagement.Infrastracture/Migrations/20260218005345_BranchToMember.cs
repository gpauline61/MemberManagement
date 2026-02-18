using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemberManagement.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class BranchToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Branch",
                table: "Members",
                newName: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_BranchID",
                table: "Members",
                column: "BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Branches_BranchID",
                table: "Members",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "BranchID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Branches_BranchID",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_BranchID",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "BranchID",
                table: "Members",
                newName: "Branch");
        }
    }
}
