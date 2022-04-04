using MVCCore.MonoProcesosDB.CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MonoProcesosDB.CRUD.Repositories
{
    public interface IProcesoCollection
    {
        void InsertProceso(Proceso proceso);
        void UpdateProceso(Proceso proceso);
        void DeleteProceso(string id);
        List<Proceso> GetAllProcesos();
        Proceso GetProcesoById(string id);

    }
}
