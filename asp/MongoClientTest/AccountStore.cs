namespace MongoClientTest.WebApp
{
    public class AccountStore : MongoStore<Account>
    {
        const string CollName = "accounts";
        const string MachineName = "localhost";
        static readonly int? Port = null;

        public AccountStore(string databaseName)
            : base(databaseName, CollName, MachineName, Port)
        {
        }

    }
}
