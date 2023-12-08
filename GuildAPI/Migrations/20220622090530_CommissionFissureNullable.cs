using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildAPI.Migrations
{
    public partial class CommissionFissureNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_Fissures_FissureID",
                table: "Commissions");

            migrationBuilder.AlterColumn<int>(
                name: "FissureID",
                table: "Commissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Commissions_Fissures_FissureID",
                table: "Commissions",
                column: "FissureID",
                principalTable: "Fissures",
                principalColumn: "FissureID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_Fissures_FissureID",
                table: "Commissions");

            migrationBuilder.AlterColumn<int>(
                name: "FissureID",
                table: "Commissions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Commissions_Fissures_FissureID",
                table: "Commissions",
                column: "FissureID",
                principalTable: "Fissures",
                principalColumn: "FissureID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
