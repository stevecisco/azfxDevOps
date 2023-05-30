//using Microsoft.Extensions.Configuration;
//using Microsoft.Azure.WebJobs;
//using ExecutionContext = Microsoft.Azure.WebJobs.ExecutionContext;
//using Azure.Identity;
//using System.Net.Sockets;
//using Azure.Security.KeyVault.Secrets;

//namespace Azure.StorageHelper
//{
//    public static class Configuration
//    {
//        public const string APP_SETTING_KEY_VAULT = "KEY_VAULT_URI";
//        public const string APP_SETTING_MAIN_STORAGE_CONNECTION = "UPLOAD_CONTAINER_CONNECTION";
//        public const string APP_SETTING_PACKAGE_BINARIES_KEYVAULT_KEY = "PACKAGE_BINARIES_KEY";
//        public const string KEY_VAULT_KEY_ADMIN_STORAGE = "admin-st";
//        public const string KEY_VAULT_KEY_ADMIN_FUNCTION = "na-fx";     //Default to north america replica if cant be found
//        public const string KEY_VAULT_KEY_DEFAULT_STORAGE = "na-st";
//        public const string KEY_VAULT_KEY_DEFAULT_FUNCTION = "na-fx";
//        public const string CONTAINER_NAME_UPLOADS = "uploads";
//        public const string CONTAINER_NAME_PACKAGE_BINARIES = "packagebinaries";


//        public static string GetAppSetting(ExecutionContext context, string key)
//        {
//            var configurationBuilder = new ConfigurationBuilder()
//                .SetBasePath(context.FunctionAppDirectory)
//                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
//                .AddEnvironmentVariables()
//                .Build();

//            string configValue = configurationBuilder[key];
//            return configValue;
//        }

//        public static Uri GetKeyVaultUri(ExecutionContext context)
//        {
//            var kvUri = GetAppSetting(context, APP_SETTING_KEY_VAULT);
//            return new Uri(kvUri);
//        }

//        public static string GetKeyVaultSecret(ExecutionContext context, string key)
//        {
//            var client = new SecretClient(GetKeyVaultUri(context), new DefaultAzureCredential());
//            var secret = client.GetSecret(key);
//            return secret.Value.Value;
//        }
//    }
//}