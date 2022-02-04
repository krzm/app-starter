using AppStarter.Data;
using AppStarter.Lib;
using AutoMapper;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppMappings 
    : DIHelper.Unity.AppMappings
{
    public AppMappings(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override MapperConfiguration CreateMap() => 
        new (
            cfg =>
            {
                cfg.CreateMap<AppInfo, AppInfoModel>();
            });
}