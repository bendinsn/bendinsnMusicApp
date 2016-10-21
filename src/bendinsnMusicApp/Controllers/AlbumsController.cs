using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bendinsnMusicApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bendinsnMusicApp.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly MusicDbContext _context;

        public AlbumsController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var albums = _context.Albums.ToList();
            ViewBag.Albums = _context.Albums.ToList();
            ViewBag.Artists = _context.Artists.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            return View(albums);
        }

        public IActionResult Add()
        {
            ViewBag.Artists = _context.Artists.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Album a)
        {
            var albums = _context.Albums;
            albums.Add(a);
            _context.SaveChanges();
            var albums2 = _context.Albums.ToList();
            ViewBag.Artists = _context.Artists.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            return View("Index", albums2);
        }

        public IActionResult Details(int id)
        {
            ViewBag.ID = id;
            ViewBag.Albums = _context.Albums.ToList();
            ViewBag.Artists = _context.Artists.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }

        public IActionResult Delete(int id)
        {
            ViewBag.ID = id;
            ViewBag.Albums = _context.Albums.ToList();
            ViewBag.Artists = _context.Artists.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }

        public IActionResult DeleteConfirmed(int id)
        {
            foreach (Album a in _context.Albums)
            {
                if (a.AlbumID == id)
                {
                    _context.Albums.Remove(a);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            ViewBag.ID = id;
            ViewBag.Albums = _context.Albums.ToList();
            ViewBag.Artists = _context.Artists.ToList();
            ViewBag.Genres = _context.Genres.ToList();

            Album album = new Album();
            foreach (Album a in ViewBag.Albums)
            {
                if (a.AlbumID == id)
                {
                    album = a;
                }
            }
            return View(album);
        }

        [HttpPost]
        public IActionResult Edit(Album album)
        {
            var albums = _context.Albums.ToList();
            Album a = albums.FirstOrDefault(x => x.AlbumID == album.AlbumID);
           
            a.Title = album.Title;
            a.ArtistID = album.ArtistID;
            a.GenreID = album.GenreID;
            a.Price = album.Price;
                
            _context.SaveChanges();
            return View("Index");
        }
    }
}
