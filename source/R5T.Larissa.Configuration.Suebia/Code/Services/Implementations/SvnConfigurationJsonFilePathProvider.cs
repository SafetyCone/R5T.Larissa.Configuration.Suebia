using System;

using R5T.Suebia;using R5T.T0064;


namespace R5T.Larissa.Configuration.Suebia
{[ServiceImplementationMarker]
    public class SvnConfigurationJsonFilePathProvider : ISvnConfigurationJsonFilePathProvider,IServiceImplementation
    {
        private ISecretsDirectoryFilePathProvider SecretsDirectoryFilePathProvider { get; }


        public SvnConfigurationJsonFilePathProvider(ISecretsDirectoryFilePathProvider secretsDirectoryFilePathProvider)
        {
            this.SecretsDirectoryFilePathProvider = secretsDirectoryFilePathProvider;
        }

        public string GetSvnConfigurationJsonFilePath()
        {
            var svnConfigurationJsonFilePath = this.SecretsDirectoryFilePathProvider.GetSecretsFilePath(FileNames.SvnConfigurationJsonFileName);
            return svnConfigurationJsonFilePath;
        }
    }
}
