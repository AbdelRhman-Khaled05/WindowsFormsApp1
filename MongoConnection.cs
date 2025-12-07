using MongoDB.Driver;

namespace TaskManagementApp
{
    public static class MongoConnection
    {
        // MongoDB Atlas connection string
        private static readonly string connectionString = "mongodb+srv://admin:U0yNNHczARoeIKpN@cluster0.xaokcb4.mongodb.net/TaskManagmentDB?retryWrites=true&w=majority&appName=Cluster0";

        private static readonly string dbName = "TaskManagmentDB"; // Note: Your DB has "Managment" not "Management"

        private static IMongoDatabase _db;

        public static IMongoDatabase GetDatabase()
        {
            if (_db == null)
            {
                var client = new MongoClient(connectionString);
                _db = client.GetDatabase(dbName);
            }
            return _db;
        }
    }
}