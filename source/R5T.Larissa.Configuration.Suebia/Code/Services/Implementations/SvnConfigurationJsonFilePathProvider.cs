using System;

using R5T.Suebia;


namespace R5T.Larissa.Configuration.Suebia
{
    public class SvnConfigurationJsonFilePathProvider : ISvnConfigurationJsonFilePathProvider
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
