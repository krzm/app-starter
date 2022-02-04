using EFCoreHelper;

namespace AppStarter.Data;

public interface IAppStarterUnitOfWork 
	: IUnitOfWork
{
	EFGenericRepository<AppInfo, AppStarterDbContext> AppInfo { get; }
}