using EFCore.Helper;
using System;

namespace AppStarter.Data;

public class AppStarterUnitOfWork 
    : UnitOfWork
        , IAppStarterUnitOfWork
{
	private readonly AppStarterDbContext context;
	private IRepository<AppInfo> appInfo;
	
    public IRepository<AppInfo> AppInfo => appInfo;

    public AppStarterUnitOfWork(
        AppStarterDbContext context
        , IRepository<AppInfo> appInfo)
            : base(context)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(appInfo);
        this.context = context;
        this.appInfo = appInfo;
    }
}