using System;
using System.Security;
using MongoDB.Driver;

namespace asp_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = GetMongoClient("localhost", null, null, null);
            Console.WriteLine("ended");
        }

        public static MongoClient GetMongoClient(

 string machineName,

 string dbName,

 string username,

 SecureString password

 )

        {

            var connString = $"mongodb://{machineName}/";

            var settings = MongoClientSettings.FromConnectionString(connString);

            if (!String.IsNullOrEmpty(username) && password != null)

            {

                var credential = MongoCredential.CreateCredential(dbName, username, password);

                settings.Credential = credential;

            }



            Console.WriteLine($"GetMongoClient - created settings: {settings}");

            Console.WriteLine($" ConnString: {connString}");

            Console.WriteLine($" HeartbeatTimeout: {settings.HeartbeatTimeout}");

            Console.WriteLine($" MaxConnectionIdleTime: {settings.MaxConnectionIdleTime}");

            Console.WriteLine($" MaxConnectionLifeTime: {settings.MaxConnectionLifeTime}");

            Console.WriteLine($" ServerSelectionTimeout: {settings.ServerSelectionTimeout}");

            Console.WriteLine($" SocketTimeout: {settings.SocketTimeout}");

            Console.WriteLine($" WaitQueueTimeout: {settings.WaitQueueTimeout}");

            return new MongoClient(settings); // <----- EXCEPTION THROWN HERE

        }

    }
}
