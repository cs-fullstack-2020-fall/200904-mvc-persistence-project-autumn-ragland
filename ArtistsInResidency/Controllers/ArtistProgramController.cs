using System;
using Microsoft.AspNetCore.Mvc;
using ArtistsInResidency.DAO;
using ArtistsInResidency.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        // view all artists
        public IActionResult ViewAll()
        {
            // return Content("View All Artist Details");
            return View(_context);
        }
        // view all artists works of art
        public IActionResult ViewArt(int artistID)
        {
            // return Content("View All Works of Art");
            // find matching artist and pass artist model object to view
            ArtistModel matchingArtist =  _context.artists.Include(artist => artist.associatedWorks).FirstOrDefault(artist => artist.id == artistID);            
            return View(matchingArtist);
        }
        // add artist
        [HttpPost]
        public IActionResult AddArtist([Bind("fName", "lName", "alias", "summary")] ArtistModel newArtist)
        {
            // return Content("Add Artist");
            // check if data entered in body of request is valid
            if(ModelState.IsValid)
            {
                // add artist to database is data is valid
                _context.Add(newArtist);
                _context.SaveChanges();
                return View("ViewAll"); 
            } else
            {
                // send errors as view data item if data is invalid
                List<string> errors = GetErrorListFromModelState(ModelState);
                string displayErrors = "";
                // build errors into string to pass to view
                errors.ForEach(error => displayErrors += $"Error : {error}\n");
                ViewData["errorMessage"] = displayErrors;
                return View("Error");
            }
        }
        // add art
        [HttpPost]
        public IActionResult AddArt([Bind("title", "medium", "description", "yearCompleted")] ArtModel newArt, int artistID)
        {
            // return Content("Add Art");
            // find artist with id matching artist id parameter
            ArtistModel matchingArtist =  _context.artists.Include(artist => artist.associatedWorks).FirstOrDefault(artist => artist.id == artistID);
            // check if matching artist is found
            if(matchingArtist != null)
            {
                // check if data passed in body of request is valid
                if(ModelState.IsValid)
                {
                    // if data is valid add art to matching artists and database
                    matchingArtist.associatedWorks.Add(newArt);
                    _context.worksOfArt.Add(newArt);
                    _context.SaveChanges();
                    return View("ViewArt", matchingArtist);
                } else 
                {
                    // send errors as view data item if data is invalid
                    List<string> errors = GetErrorListFromModelState(ModelState);
                    string displayErrors = "";
                    // build errors into string to pass to view
                    errors.ForEach(error => displayErrors += $"Error : {error}\n");
                    ViewData["errorMessage"] = displayErrors;
                    return View("Error");
                }
            } else
            {
                // if matching artist is found
                ViewData["errorMessage"] = "No Artist Found";
                return View("Error");
            }
        }
        // output all model state errors - COPIED CODE
        public static List<string> GetErrorListFromModelState(ModelStateDictionary modelState)
        {
            IEnumerable<string> query = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;
            List<string> errorList = query.ToList();
            return errorList;
        }
    }
}