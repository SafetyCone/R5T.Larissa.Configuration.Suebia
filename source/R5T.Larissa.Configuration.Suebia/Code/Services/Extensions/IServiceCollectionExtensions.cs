using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Suebia;


namespace R5T.Larissa.Configuration.Suebia
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SvnConfigurationJsonFilePathProvider"/> implementation of <see cref="ISvnConfigurationJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSvnConfigurationJsonFilePathProvider(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            services
                .AddSingleton<ISvnConfigurationJsonFilePathProvider, SvnConfigurationJsonFilePathProvider>()
                .Run(secretsDirectoryFilePathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SvnConfigurationJsonFilePathProvider"/> implementation of <see cref="ISvnConfigurationJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISvnConfigurationJsonFilePathProvider> AddSvnConfigurationJsonFilePathProviderAction(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<ISvnConfigurationJsonFilePathProvider>(() => services.AddSvnConfigurationJsonFilePathProvider(
                secretsDirectoryFilePathProviderAction));

            return serviceAction;
        }
    }
}
