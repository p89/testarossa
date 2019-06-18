using System.Reflection;
using System.Linq;
using Autofac;
using testarossa.Infrastructure.Services;

namespace testarossa.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
            .GetTypeInfo()
            .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x=>x.IsAssignableTo<IService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}