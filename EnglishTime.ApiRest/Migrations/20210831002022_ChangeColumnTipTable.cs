using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishTime.ApiRest.Migrations
{
    public partial class ChangeColumnTipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tip",
                newName: "Phrase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phrase",
                table: "Tip",
                newName: "Name");
        }
    }
}
