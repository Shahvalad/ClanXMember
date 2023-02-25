using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClanXMember.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Clans_ClanId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_ClanId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Clans",
                newName: "Capacity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Clans",
                newName: "Age");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ClanId",
                table: "Members",
                column: "ClanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Clans_ClanId",
                table: "Members",
                column: "ClanId",
                principalTable: "Clans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
