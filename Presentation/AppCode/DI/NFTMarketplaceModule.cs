using Application;
using Autofac;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Repository;

namespace Presentation.AppCode.DI
{
    public class NFTMarketplaceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<DataAccessModule>();

            builder.RegisterAssemblyModules(typeof(DataAccessModule).Assembly);
            builder.RegisterAssemblyModules(typeof(ApplicationModule).Assembly);

            builder.RegisterAssemblyTypes(typeof(IRepositoryReference).Assembly)
                .AsImplementedInterfaces();
        }
    }
}
