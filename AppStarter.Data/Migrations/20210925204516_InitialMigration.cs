using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStarter.Data.Migrations
{
	public partial class InitialMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "AppInfo",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
					Path = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AppInfo", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AppInfo");
		}
	}
}