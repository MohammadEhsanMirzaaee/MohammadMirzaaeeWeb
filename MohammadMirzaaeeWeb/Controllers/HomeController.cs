using _1_Repository;
using MohammadMirzaaeeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MohammadMirzaaeeWeb.Controllers
{
    public class HomeController : Controller
    {
        CategoriesRepository CategoriesRepository;
        BuildingsRepository BuildingsRepository;

        public HomeController()
        {
            CategoriesRepository = new CategoriesRepository();
            BuildingsRepository = new BuildingsRepository();
        }

        public ActionResult Home()
        {
            CategoryViewModel cvm = new CategoryViewModel();
            cvm.CategoriesList = CategoriesRepository.CategoriesList();
            return View(cvm);
        }
        public ActionResult CategoriesList()
        {
            CategoryViewModel cvm = new CategoryViewModel();
            cvm.CategoriesList = CategoriesRepository.CategoriesList();
            return View(cvm);
        }
        public ActionResult Building(Building building)
        {
            BuildingViewModel bvm = new BuildingViewModel();
            bvm.Building = BuildingsRepository.GetBuilding(building);
            return View(bvm);
        }
        public ActionResult BuildingsList(Category category)
        {
            BuildingViewModel bvm = new BuildingViewModel();
            bvm.BuildingsList = BuildingsRepository.BuldingsListById(category);
            return View(bvm);
        }
    }
}