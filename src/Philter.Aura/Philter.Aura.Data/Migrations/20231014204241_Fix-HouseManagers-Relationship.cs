using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Philter.Aura.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixHouseManagersRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseManagers_Users_ManagerId",
                table: "HouseManagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseManagers",
                table: "HouseManagers");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "HouseManagers",
                newName: "AuraUserId");

            migrationBuilder.RenameIndex(
                name: "IX_HouseManagers_ManagerId",
                table: "HouseManagers",
                newName: "IX_HouseManagers_AuraUserId");

            migrationBuilder.AddColumn<int>(
                name: "HouseManagerId",
                table: "HouseManagers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseManagers",
                table: "HouseManagers",
                column: "HouseManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseManagers_HouseId_AuraUserId",
                table: "HouseManagers",
                columns: new[] { "HouseId", "AuraUserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseManagers_Users_AuraUserId",
                table: "HouseManagers",
                column: "AuraUserId",
                principalTable: "Users",
                principalColumn: "AuraUserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseManagers_Users_AuraUserId",
                table: "HouseManagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseManagers",
                table: "HouseManagers");

            migrationBuilder.DropIndex(
                name: "IX_HouseManagers_HouseId_AuraUserId",
                table: "HouseManagers");

            migrationBuilder.DropColumn(
                name: "HouseManagerId",
                table: "HouseManagers");

            migrationBuilder.RenameColumn(
                name: "AuraUserId",
                table: "HouseManagers",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_HouseManagers_AuraUserId",
                table: "HouseManagers",
                newName: "IX_HouseManagers_ManagerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseManagers",
                table: "HouseManagers",
                columns: new[] { "HouseId", "ManagerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HouseManagers_Users_ManagerId",
                table: "HouseManagers",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "AuraUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
