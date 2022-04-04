using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MonoProcesosDB.CRUD.Repositories
{
    public class MonoprocesosDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MonoprocesosDBRepository()
        {
            client = new MongoClient("mongodb://localhost/27017");

            db = client.GetDatabase("Monolegal");
        }
    }
}
