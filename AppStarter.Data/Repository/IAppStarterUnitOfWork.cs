using AppStarter.Data.Model;
using Core;
using Core.Lib;

namespace AppStarter.Data.Repository
{
	public interface IAppStarterUnitOfWork : IUnitOfWork
	{
		EFGenericRepository<AppInfo, AppStarterDbContext> AppInfo { get; }
	}
}