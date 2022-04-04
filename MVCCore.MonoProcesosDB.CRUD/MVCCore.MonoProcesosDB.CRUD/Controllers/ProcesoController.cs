using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCore.MonoProcesosDB.CRUD.Models;
using MVCCore.MonoProcesosDB.CRUD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MonoProcesosDB.CRUD.Controllers
{
    public class ProcesoController : Controller
    {
        private IProcesoCollection db = new ProcesoCollection();
        // GET: Proceso
        public ActionResult Index()
        {
            var procesos = db.GetAllProcesos();
            return View(procesos);
        }

        // GET: Proceso/Details/5
        public ActionResult Details(string id)
        {
            var proceso = db.GetProcesoById(id);
            return View(proceso);
        }

        // GET: Proceso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proceso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var proceso = new Proceso()
                {
                    Cliente = collection["Cliente"],
                    Ciudad = collection["Ciudad"],
                    NIT = Double.Parse(collection["NIT"]),
                    Total_Factura = decimal.Parse(collection["Total_Factura"]),
                    Subtotal = decimal.Parse(collection["Subtotal"]),
                    Iva = decimal.Parse(collection["Iva"]),
                    Retencion = int.Parse(collection["Retencion"]),
                    Fecha_Creacion = DateTime.Parse(collection["Fecha_Creacion"]),
                    Estado = collection["Estado"],
                    Pagada = Boolean.Parse(collection["Pagada"]),
                    Fecha_Pago = collection["Fecha_Pago"]
                };

                db.InsertProceso(proceso);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Proceso/Edit/5
        public ActionResult Edit(string id)
        {
            var proceso = db.GetProcesoById(id);
            return View(proceso);
        }

        // POST: Proceso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var proceso = new Proceso()
                {
                    Codigo_Factura = new MongoDB.Bson.ObjectId(id),
                    Cliente = collection["Cliente"],
                    Ciudad = collection["Ciudad"],
                    NIT = Double.Parse(collection["NIT"]),
                    Total_Factura = decimal.Parse(collection["Total_Factura"]),
                    Subtotal = decimal.Parse(collection["Subtotal"]),
                    Iva = decimal.Parse(collection["Iva"]),
                    Retencion = int.Parse(collection["Retencion"]),
                    Fecha_Creacion = DateTime.Parse(collection["Fecha_Creacion"]),
                    Estado = collection["Estado"],
                    Pagada = Boolean.Parse(collection["Pagada"]),
                    Fecha_Pago = collection["Fecha_Pago"]
                };

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Proceso/Delete/5
        public ActionResult Delete(string id)
        {
            var proceso = db.GetProcesoById(id);

            return View(proceso);
        }

        // POST: Proceso/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                db.DeleteProceso(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
