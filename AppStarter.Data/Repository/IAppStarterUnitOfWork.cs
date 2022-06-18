using EFCore.Helper;

namespace AppStarter.Data;

public interface IAppStarterUnitOfWork 
	: IUnitOfWork
{
	IRepository<AppInfo> AppInfo { get; }
}