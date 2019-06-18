using Autofac;
using Microsoft.Extensions.Configuration;
using testarossa.Infrastructure.Mappers;

namespace testarossa.Infrastructure.IoC.Modules
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}