using Microsoft.EntityFrameworkCore;

namespace AppStarter.Data;

public class AppStarterDbContext : DbContext
{
	public DbSet<AppInfo> AppInfo { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AppStarter");
	}
}