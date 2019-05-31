using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodPicker.Controllers
{
    public class FoodController : Controller
    {
        private readonly UnitOfWork _uw;
        public FoodController()
        {
            _uw = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<Food> foodList = _uw.foodRep.GetAll();
            return View(foodList);
        }

        public ActionResult AddFood()
        {
            List<Restaurant> restaurant = _uw.restRep.GetAll();
            var restaurantList = restaurant.Select(x => new SelectListItem()
            {
                Text = x.RestaurantName,
                Value = x.Id.ToString()
            });
            ViewBag.list = restaurantList;

            return View();
        }
        [HttpPost]
        public ActionResult AddFood(Food food)
        {
            if (ModelState.IsValid) //checks if the model is valid
            {
                _uw.studentRep.Insert(student); //Add

                return RedirectToAction("Index"); //Go to Home
            }

            //We stil need DropDownList so we keep this here as the 
            var edu = _uw.educationRep.Get();
            var list = edu.Select(x => new SelectListItem()
            {
                Text = x.EduName,
                Value = x.EduId.ToString()
            });
            ViewBag.list = list;

            return View();
        }
    }
}