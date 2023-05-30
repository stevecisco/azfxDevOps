using Azure.Data.Tables;
using Azure.Storage.Queues;
using Microsoft.Extensions.Logging;

namespace Azure.StorageHelper
{
    public static class StorageHelper
    {
        public static async Task DeleteTable(string connectionString, string tableName, string replicaKey, ILogger log)
        {
            try
            {
                var tableClient = new TableClient(connectionString, tableName);
                await tableClient.DeleteAsync();
                log.LogInformation($"fxResetPackagesDownloadsAndBinaries-DeleteTable-[{replicaKey}:{tableName}] completed successfully");
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"fxResetPackagesDownloadsAndBinaries-DeleteTable-[{replicaKey}:{tableName}] encountered an error");
                throw;
            }
        }

        public static async Task DeleteQueue(string connectionString, string queueName, string replicaKey, ILogger log)
        {
            try
            {
                var qClient = new QueueClient(connectionString, queueName);
                await qClient.DeleteAsync();
                log.LogInformation($"fxResetPackagesDownloadsAndBinaries-DeleteQueue-[{replicaKey}:{queueName}] completed successfully");
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"fxResetPackagesDownloadsAndBinaries-DeleteQueue-[{replicaKey}:{queueName}] encountered an error");
                throw;
            }
        }


        public static async Task CreateTable(string connectionString, string tableName, string replicaKey, ILogger log)
        {
            try
            {
                var tableClient = new TableClient(connectionString, tableName);
                await tableClient.CreateIfNotExistsAsync();
                log.LogInformation($"fxResetPackagesDownloadsAndBinaries-CreateTable-[{replicaKey}:{tableName}] completed successfully");
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"fxResetPackagesDownloadsAndBinaries-CreateTable-[{replicaKey}:{tableName}] encountered an error");
                throw;
            }
        }


        public static async Task CreateQueue(string connectionString, string queueName, string replicaKey, ILogger log)
        {
            try
            {
                var qClient = new QueueClient(connectionString, queueName);
                await qClient.CreateIfNotExistsAsync();
                log.LogInformation($"fxResetPackagesDownloadsAndBinaries-CreateQueue-[{replicaKey}:{queueName}] completed successfully");
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"fxResetPackagesDownloadsAndBinaries-CreateQueue-[{replicaKey}:{queueName}] encountered an error");
                throw;
            }
        }

    }
}
