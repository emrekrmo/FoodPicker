using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodPicker.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly UnitOfWork _uw;
        public RestaurantController()
        {
            _uw = new UnitOfWork();
        }
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddRestaurant()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _uw.restRep.Create(restaurant);
                return RedirectToAction("AddFood","Food");
            }
            return View();
        }
    }
}