using System;
using Microsoft.AspNetCore.Mvc;
using ArtistsInResidency.DAO;
// controller for all routes associated with artist and art CRUD methods
namespace ArtistsInResidency.Controllers
{
    public class ArtistProgram : Controller
    {
        // reference to database
        private readonly ArtistDbContext _context;
        public ArtistProgram(ArtistDbContext context)
        {
            _context = context;
        }
        // landing page with navigation
        public IActionResult Index()
        {
            // return Content("Landing with Navigation");
            return View();
        }
        // view all artists
        public IActionResult ViewAll()
        {
            // return Content("View All Artist Details");
            return View();
        }
        // view all artists works of art
        public IActionResult ViewArt()
        {
            // return Content("View All Works of Art");
            return View();
        }
        // add artist
        [HttpPost]
        public IActionResult AddArtist()
        {
            // return Content("Add Artist");
            return View("ViewAll");
        }
        // add art
        [HttpPost]
        public IActionResult AddArt()
        {
            // return Content("Add Art");
            return View("ViewAll");
        }
        // update art
        [HttpPut]
        public IActionResult UpdateArt()
        {
            // return Content("Update Art");
            return View("ViewAll");
        }
        // delete art
        [HttpDelete]
        public IActionResult DeleteArt()
        {
            // return Content("Delete Art");
            return View("ViewAll");
        }
    }
}