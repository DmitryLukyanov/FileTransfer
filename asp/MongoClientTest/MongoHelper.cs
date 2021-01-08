using System;
using System.Security;
using MongoDB.Driver;

namespace MongoClientTest.WebApp
{
    public static class MongoHelper
    {
        /// <summary>
        /// Returns a MongoDB client, using the given credentials if provided
        /// </summary>
        public static MongoClient GetMongoClient(
                                    string machineName, 
                                    int? port,
                                    string dbName, 
                                    string username, 
                                    SecureString password
                                    )
        {
            var connString = GetConnString(machineName, port);
            var settings = MongoClientSettings.FromConnectionString(connString);

            if (!String.IsNullOrEmpty(username) && password != null)
            {
                var credential = MongoCredential.CreateCredential(dbName, username, password);
                settings.Credential = credential;
            }
          
            Log.Debug($"GetMongoClient - created settings: {settings}");
            Log.Debug($"                      ConnString:             {connString}");
            Log.Debug($"                      HeartbeatTimeout:       {settings.HeartbeatTimeout}");
            Log.Debug($"                      MaxConnectionIdleTime:  {settings.MaxConnectionIdleTime}");
            Log.Debug($"                      MaxConnectionLifeTime:  {settings.MaxConnectionLifeTime}");
            Log.Debug($"                      ServerSelectionTimeout: {settings.ServerSelectionTimeout}");
            Log.Debug($"                      SocketTimeout:          {settings.SocketTimeout}");
            Log.Debug($"                      WaitQueueTimeout:       {settings.WaitQueueTimeout}");

            return new MongoClient(settings);
        }

        static string GetConnString(string databaseMachine, int? databasePort)
        {
            if (databasePort == null)
            {
                return $"mongodb://{databaseMachine}/";
            }

            return $"mongodb://{databaseMachine}:{databasePort}/";
        }


    }
}
