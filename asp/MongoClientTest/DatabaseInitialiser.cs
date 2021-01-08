using System;

namespace MongoClientTest.WebApp
{
    public class DatabaseInitialiser
    {
        readonly IStore[] _allStores;

        public DatabaseInitialiser(IStore[] allStores)
        {
            _allStores = allStores;
        }

        public void Initialise()
        {
            try
            {
                Log.General("Initialising all MongoDB stores...'");

                foreach (var store in _allStores)
                {
                    var name = store.GetType().Name;

                    // Run simple query on database to see if it's accessible
                    Log.General($"Accessing store: {name}");
                    store.IsEmpty();
                    Log.General($"Sucessfully accessed store: {name}");
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(DatabaseInitialiser)} failed: {ex}");
                Log.LogUnhandledExceptionMessage(ex);
                throw;
            }
        }
    }
}