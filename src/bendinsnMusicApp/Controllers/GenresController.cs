using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bendinsnMusicApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bendinsnMusicApp.Controllers
{
    public class GenresController : Controller
    {
        private readonly MusicDbContext _context;

        public GenresController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var genres = _context.Genres.ToList();
            return View(genres);
        }

        public IActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre g)
        {
            var genres = _context.Genres;
            genres.Add(g);
            _context.SaveChanges();
            //return RedirectToAction("Index");
            var genres2 = _context.Genres.ToList();
            return View("Index", genres2);
        }

        public IActionResult Albums(int id)
        {
            ViewBag.ID = id;
            ViewBag.Albums = _context.Albums.ToList();
            ViewBag.Artists = _context.Artists.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }
    }
}
