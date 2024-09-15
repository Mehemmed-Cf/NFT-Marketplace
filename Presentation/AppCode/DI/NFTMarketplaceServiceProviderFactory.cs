using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Presentation.AppCode.DI
{
    public class NFTMarketplaceServiceProviderFactory : AutofacServiceProviderFactory
    {
        public NFTMarketplaceServiceProviderFactory()
            :base(OnRegister)
        {
        }

        private static void OnRegister(ContainerBuilder builder)
        {
            builder.RegisterModule<NFTMarketplaceModule>();
        }
    }
}
