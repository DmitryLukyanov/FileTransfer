using MongoDB.Driver;

namespace MongoClientTest.WebApp
{
    public abstract class MongoStore<TModel> : IStore where TModel : StoreModel
    {
        protected IMongoDatabase Database;
        protected IMongoCollection<TModel> Collection => Database.GetCollection<TModel>(CollectionName);

        public string DatabaseName { get; }
        public string CollectionName { get; }

        protected MongoStore(string databaseName, string collectionName, string databaseMachine, int? port)
        {
            var client = MongoHelper.GetMongoClient(databaseMachine, port, databaseName, null, null);
            Database = client.GetDatabase(databaseName);

            DatabaseName = databaseName;
            CollectionName = collectionName;
        }

        public bool IsEmpty()
        {
            return !Collection.FindSync(FilterDefinition<TModel>.Empty).Any();
        }
    }
}