using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCore.MongoDB.CRUD.Models;
using MVCCore.MongoDB.CRUD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Controllers
{
    public class SongController : Controller
    {
        private IAlbumCollection db = new AlbumCollection();
        public IActionResult Index()
        {
            return View();
        }

        // GET: Song/Create
        public ActionResult Create(string id)
        {
            SongViewModels songVM = new SongViewModels() { AlbumId = id, Song = new Song() };
            return View(songVM);
        }

        // POST: Song/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                var album = db.GetAlbumById(collection["AlbumId"]);
                if (album.Songs == null)
                    album.Songs = new List<Song>();

                album.Songs.Add(new Song
                {
                    Name = collection["Song.Name"],
                    Duration = int.Parse(collection["Song.Duration"])
                });

                db.UpdateAlbum(album);

                return RedirectToAction("Index", "Album");
            }
            catch
            {
                return View();
            }
        }
    }
}
