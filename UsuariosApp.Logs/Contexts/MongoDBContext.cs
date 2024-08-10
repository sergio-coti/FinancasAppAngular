using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Logs.Collections;
using UsuariosApp.Logs.Settings;

namespace UsuariosApp.Logs.Contexts
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase? _database;

        public MongoDBContext()
        {
            var mongoClient = MongoClientSettings.FromUrl
                (new MongoUrl(MongoDBSettings.Host));

            var client = new MongoClient(mongoClient);
            _database = client.GetDatabase(MongoDBSettings.Database);
        }

        public IMongoCollection<LogUsuarios> LogUsuarios
            => _database.GetCollection<LogUsuarios>("LogUsuarios");
    }
}
