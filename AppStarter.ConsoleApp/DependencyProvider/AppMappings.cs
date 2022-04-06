using AppStarter.Data;
using AppStarter.Lib;
using AutoMapper;
using Unity;

namespace AppStarter.ConsoleApp;

public class AppMappings 
    : ModelHelper.AppMappings
{
    public AppMappings(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override MapperConfiguration CreateMap() => 
        new (
        c =>
        {
            c.CreateMap<AppInfo, AppInfoModel>();
        });
}