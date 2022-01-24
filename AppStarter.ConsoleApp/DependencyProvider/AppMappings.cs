using AppStarter.Data.Model;
using AppStarter.Lib.Model;
using AutoMapper;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppMappings : CLI.Core.Lib.AppMappings
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