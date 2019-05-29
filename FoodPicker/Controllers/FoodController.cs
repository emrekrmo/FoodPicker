﻿using BLL;
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
    }
}