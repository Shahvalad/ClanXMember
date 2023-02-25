using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClanXMember.Migrations
{
    /// <inheritdoc />
    public partial class ClanMemberRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClanId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clans", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Clans_ClanId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Clans");

            migrationBuilder.DropIndex(
                name: "IX_Members_ClanId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ClanId",
                table: "Members");
        }
    }
}
