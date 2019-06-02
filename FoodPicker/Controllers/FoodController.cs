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
            List<Food> foodList = _uw.foodRep.GetAll();
            return View(foodList);
        }

        public ActionResult DeleteFood(int id)
        {
            _uw.foodRep.Delete(id);
            _uw.Save();

            return RedirectToAction("Index", "Food");
        }

        public ActionResult AddFood()
        {
            IEnumerable<Restaurant> restaurant = _uw.restRep.GetAll();
            var restaurantList = restaurant.Select(x => new SelectListItem()
            {
                Text = x.RestaurantName,
                Value = x.Id.ToString()
            });
            ViewBag.restaurantList = restaurantList;

            ViewBag.foodTypes = new SelectList(Enum.GetValues(typeof(FoodType))
                .OfType<Enum>()
                .Select(x => new SelectListItem
            {
                Text = Enum.GetName(typeof(FoodType), x),
                Value = (Convert.ToInt32(x)).ToString()
            }), "Value", "Text");

            return View();
        }
        [HttpPost]
        public ActionResult AddFood(Food food)
        {
            if (ModelState.IsValid) //checks if the model is valid
            {
                _uw.foodRep.Create(food); //Add
                _uw.Save();

                return RedirectToAction("Index", "Food"); //Go to Home
            }

            //We stil need DropDownList so we keep this here as the 
            List<Restaurant> restaurant = _uw.restRep.GetAll();
            var restaurantList = restaurant.Select(x => new SelectListItem()
            {
                Text = x.RestaurantName,
                Value = x.Id.ToString()
            });
            ViewBag.RestaurantList = restaurantList;

            ViewBag.foodTypes = new SelectList(Enum.GetValues(typeof(FoodType))
                .OfType<Enum>()
                .Select(x => new SelectListItem
                {
                    Text = Enum.GetName(typeof(FoodType), x),
                    Value = (Convert.ToInt32(x)).ToString()
                }), "Value", "Text");

            return View(food);
        }

        public ActionResult EditFood(int? id)
        {
            if (!id.HasValue) //if int is null. We need to check this as we set id nullable
                return HttpNotFound();

            List<Restaurant> restaurant = _uw.restRep.GetAll();
            var restaurantList = restaurant.Select(x => new SelectListItem()
            {
                Text = x.RestaurantName,
                Value = x.Id.ToString()
            });
            ViewBag.RestaurantList = restaurantList;

            ViewBag.foodTypes = new SelectList(Enum.GetValues(typeof(FoodType))
                .OfType<Enum>()
                .Select(x => new SelectListItem
                {
                    Text = Enum.GetName(typeof(FoodType), x),
                    Value = (Convert.ToInt32(x)).ToString()
                }), "Value", "Text");

            return View(_uw.foodRep.GetById(id.Value));
        }
        [HttpPost]
        public ActionResult EditFood(Food food)
        {
            if (ModelState.IsValid)
            {
                _uw.foodRep.Update(food);
                _uw.Save();

                return RedirectToAction("Index", "Food");
            }

            List<Restaurant> restaurant = _uw.restRep.GetAll();
            var restaurantList = restaurant.Select(x => new SelectListItem()
            {
                Text = x.RestaurantName,
                Value = x.Id.ToString()
            });
            ViewBag.RestaurantList = restaurantList;

            ViewBag.foodTypes = new SelectList(Enum.GetValues(typeof(FoodType))
                .OfType<Enum>()
                .Select(x => new SelectListItem
                {
                    Text = Enum.GetName(typeof(FoodType), x),
                    Value = (Convert.ToInt32(x)).ToString()
                }), "Value", "Text");

            return View(food); //shows the last written values
        }
    }
}