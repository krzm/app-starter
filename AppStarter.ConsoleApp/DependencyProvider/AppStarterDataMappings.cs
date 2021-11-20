using AppStarter.Data.Model;
using AppStarter.Lib.Model;
using AutoMapper;
using Console.Lib;
using Unity;

namespace AppStarter.ConsoleApp
{
    public class AppStarterDataMappings
        : DataMappings
    {
        public AppStarterDataMappings(
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