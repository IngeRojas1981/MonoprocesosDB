using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MonoProcesosDB.CRUD.Models
{
    public class Proceso
    {
        [BsonId]
        public ObjectId Codigo_Factura { get; set; }
        public string Cliente { get; set; }
        public string Ciudad { get; set; }
        public Double NIT { get; set; }
        public Decimal Total_Factura { get; set; }
        public Decimal Subtotal { get; set; }
        public Decimal Iva { get; set; }
        public int Retencion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Estado { get; set; }
        public Boolean Pagada { get; set; }
        public string Fecha_Pago { get; set; }
    }
}
