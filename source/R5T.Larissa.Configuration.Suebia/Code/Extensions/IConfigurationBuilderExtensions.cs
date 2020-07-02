using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Suebia.Extensions;


namespace R5T.Larissa.Configuration.Suebia
{
    public static class IConfigurationBuilderExtensions
    {
        /// <summary>
        /// Uses the <see cref="R5T.Suebia.ISecretsDirectoryFilePathProvider"/> service and <see cref="FileNames.SvnConfigurationJsonFileName"/>.
        /// </summary>
        public static IConfigurationBuilder AddSvnConfigurationJsonFileFromSecretsDirectory(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            configurationBuilder.AddJsonSecretsFilePath(configurationServiceProvider, FileNames.SvnConfigurationJsonFileName);

            return configurationBuilder;
        }

        /// <summary>
        /// Uses the <see cref="ISvnConfigurationJsonFilePathProvider"/> service.
        /// </summary>
        public static IConfigurationBuilder AddSvnConfigurationJsonFileDirect(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            var svnConfigurationJsonFilePathProvider = configurationServiceProvider.GetRequiredService<ISvnConfigurationJsonFilePathProvider>();

            var svnConfigurationJsonFilePath = svnConfigurationJsonFilePathProvider.GetSvnConfigurationJsonFilePath();

            configurationBuilder.AddJsonFile(svnConfigurationJsonFilePath);

            return configurationBuilder;
        }

        /// <summary>
        /// Default uses the <see cref="AddSvnConfigurationJsonFileDirect(IConfigurationBuilder, IServiceProvider)"/> method.
        /// </summary>
        public static IConfigurationBuilder AddSvnConfigurationJsonFile(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            configurationBuilder.AddSvnConfigurationJsonFileDirect(configurationServiceProvider);

            return configurationBuilder;
        }
    }
}
