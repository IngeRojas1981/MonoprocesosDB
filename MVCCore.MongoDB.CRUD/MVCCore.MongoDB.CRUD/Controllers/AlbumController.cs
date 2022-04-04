using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MVCCore.MongoDB.CRUD.Models;
using MVCCore.MongoDB.CRUD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumCollection db = new AlbumCollection();
        // GET: Album
        public ActionResult Index()
        {
            var albums = db.GetAllAlbums();
            return View(albums);
        }

        // GET: Album/5
        public ActionResult Details(string id)
        {
            var album = db.GetAlbumById(id);
            return View(album);
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var album = new Album()
                {
                    AlbumName = collection["AlbumName"],
                    Duration = int.Parse(collection["Duration"]),
                    Artist = collection["Artist"],
                    ReleaseDate = DateTime.Parse(collection["ReleaseDate"])
                };

                db.InsertAlbum(album);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(string id)
        {
            var album = db.GetAlbumById(id);
            return View(album);
        }

        // POST: Album/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var album = new Album()
                {
                    Id = new ObjectId(id),
                    AlbumName = collection["AlbumName"],
                    Duration = int.Parse(collection["Duration"]),
                    Artist = collection["Artist"],
                    ReleaseDate = DateTime.Parse(collection["ReleaseDate"])
                };
                db.UpdateAlbum(album);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(string id)
        {
            var album = db.GetAlbumById(id);

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                db.DeleteAlbum(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
