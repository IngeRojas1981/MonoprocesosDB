using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");

            db = client.GetDatabase("MusicCatalog");
        }
    }
}
