using MongoDB.Bson;
using MongoDB.Driver;
using MVCCore.MonoProcesosDB.CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MonoProcesosDB.CRUD.Repositories
{
    public class ProcesoCollection : IProcesoCollection
    {
        internal MonoprocesosDBRepository _repository = new MonoprocesosDBRepository();
        private IMongoCollection<Proceso> Collection;

        public ProcesoCollection()
        {
            Collection = _repository.db.GetCollection<Proceso>("Procesos");
        }

        public void DeleteProceso(string id)
        {
            var filter = Builders<Proceso>.Filter.Eq(s => s.Codigo_Factura, new ObjectId(id));
            Collection.DeleteOneAsync(filter);
        }

        public List<Proceso> GetAllProcesos()
        {
            var query = Collection.
                Find(new BsonDocument()).ToListAsync();

            return query.Result;
        }

        public Proceso GetProcesoById(string id)
        {
            var proceso = Collection.Find(
                new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;

            return proceso;
        }

        public void InsertProceso(Proceso proceso)
        {
            Collection.InsertOneAsync(proceso);
        }

        public void UpdateProceso(Proceso proceso)
        {
            var filter = Builders<Proceso>
                .Filter
                .Eq(s => s.Codigo_Factura, proceso.Codigo_Factura);
            Collection.ReplaceOneAsync(filter, proceso);
        }
    }
}
