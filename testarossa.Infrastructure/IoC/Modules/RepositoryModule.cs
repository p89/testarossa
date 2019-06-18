using System.Reflection;
using System.Linq;
using Autofac;
using testarossa.Core.Repositories;

namespace testarossa.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
            .GetTypeInfo()
            .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x=>x.IsAssignableTo<IRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}