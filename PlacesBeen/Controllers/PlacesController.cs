using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PlacesBeen.Models;

namespace PlacesBeen.Controllers
{
    public class PlacesController : Controller
    {

      [HttpGet("/places")]
      public ActionResult Index()
      {
        List<Place> allPlaces = Place.GetAll();
        return View(allPlaces);
      }

      [HttpGet("/places/new")]
      public ActionResult New()
      {
        return View();
      }

      [HttpPost("/places")]
      public ActionResult Create(string city)
      {
        Place myPlace = new Place(city);
        return RedirectToAction("Index");
      }

      [HttpPost("/places/delete")]
      public ActionResult DeleteAll()
      {
        Place.ClearAll();
        return View();
      }
      
      [HttpGet("/places/{id}")]
      public ActionResult Show(int id)
      {
        Place foundPlace = Place.Find(id);
        return View(foundPlace);
      }
    }
}