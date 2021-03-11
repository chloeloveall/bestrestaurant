using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurant.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly BestRestaurantContext _db;
    // This is a variable for the databases
    public CuisinesController(BestRestaurantContext db)
    {
      _db = db;
      // Seems like a setter but isn't?
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      // This gets a list of all the data from the Cuisines table and converts it into a List<Cuisine>
      return View(model);
      // This sends said list to the Cuisines/Index.cshtml
    }

    public ActionResult Create()
    {
      return View();
      // All this does is redirect to Cuisines/Create.cshtml when called.
      // Guess all the work happens in that webpage.
    }

    // Data submit event triggered by the button in Cuisines/Create.cshtml
    [HttpPost]
    // This takes the Cuisine Name submitted by the button as a parameter
    public ActionResult Create(Cuisine category)
    {
      // Adds the new Name to the Cuisine database
      _db.Cuisines.Add(category);
      // Saves
      _db.SaveChanges();
      // And dumps the user back to Cuisines/
      return RedirectToAction("Index");
    }

    // This takes in a provided ID retrieved from Cuisines/Index.cshtml
    public ActionResult Details(int id)
    {
      // Creates a Cuisine object called thisCuisine, which looks through the database for the Cuisine ID that matches the submitted ID
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(category => category.CuisineId == id);

      // TESTING
      // This should create a list object of all the Restaurant database info
      Restaurant model = _db.Restaurants.FirstOrDefault(category => category.CuisineId == id);
      // 

      // Returns the Details page, now populated by the Cuisine that matches this ID
      return View(model);
      // Can't just do return View(model); because the Details page matching this ID needs a Cuisine object
    }
    public ActionResult Edit(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(category => category.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Edit(Cuisine category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(category => category.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(category => category.CuisineId == id);
      _db.Cuisines.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}