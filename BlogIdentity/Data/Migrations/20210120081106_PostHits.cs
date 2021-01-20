using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogIdentity.Data.Migrations
{
    public partial class PostHits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Hits",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hits",
                table: "Posts");
        }
    }
}
