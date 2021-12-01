using AppStarter.Data.Model;
using AppStarter.Lib.Model;
using AutoMapper;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppMappings : Console.Lib.AppMappings
    {
        public AppMappings(
            IUnityContainer container) 
            : base(container)
        {
        }

        public override void RegisterDependencies()
        {
            var config = new MapperConfiguration(
                cfg => 
                {
                    cfg.CreateMap<AppInfo, AppInfoModel>();
                });
                
			Container.RegisterInstance(config.CreateMapper());
        }
    }
}