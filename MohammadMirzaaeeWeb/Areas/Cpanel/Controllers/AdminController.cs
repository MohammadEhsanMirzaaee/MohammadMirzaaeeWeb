using _1_Repository;
using MohammadMirzaaeeWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MohammadMirzaaeeWeb.Areas.Cpanel.Controllers
{
    public class AdminController : Controller
    {
        CategoriesRepository CategoriesRepository;
        BuildingsRepository BuildingsRepository;

        public AdminController()
        {
            CategoriesRepository = new CategoriesRepository();
            BuildingsRepository = new BuildingsRepository();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult AddContent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Building building, HttpPostedFileBase file)
        {
            return View();
        }
        public ActionResult UploadContentImage()
        {
            var file = Request.Files["Filedata"];
            string extension = Path.GetExtension(file.FileName);
            string fileid = Guid.NewGuid().ToString();
            fileid = Path.ChangeExtension(fileid, extension);

            string savePath = Server.MapPath(@"~\images\content" + fileid);
            file.SaveAs(savePath);

            return Content(Url.Content(@"~\images\content" + fileid));
        }
        public ActionResult AddCategory(CategoryViewModel cvm)
        { 
            return View(cvm);
        }

        [HttpPost]
        public ActionResult AddCategory(Category category, HttpPostedFileBase file)
        {
            string pic = System.IO.Path.GetFileName(file.FileName);
            string path = System.IO.Path.Combine(
                                   Server.MapPath("~/images/main"), pic);
            file.SaveAs(path);
            category.ImageAddress = "/images/main/" + pic;
            CategoryViewModel cvm = new CategoryViewModel();
            CategoriesRepository.Add(category);
            cvm.EndUserMessage = "با موفقیت اضافه شد";
            return View(cvm);
        }
        public ActionResult CategoriesList()
        {
            CategoryViewModel cvm = new CategoryViewModel();
            cvm.CategoriesList = CategoriesRepository.CategoriesList();
            return View(cvm);
        }
        public ActionResult AddBuilding()
        {
            return View();
        }
        public ActionResult BuldingsList(BuildingViewModel bvm)
        {
            return View(bvm);
        }

        public ActionResult BuldingsListById(Category category)
        {
            BuildingViewModel bvm = new BuildingViewModel();
            bvm.BuildingsList = BuildingsRepository.BuldingsListById(category);
            return View("BuldingsList", bvm);
        }

        public ActionResult EditContentPage(Building building)
        {
            BuildingViewModel bvm = new BuildingViewModel();
            bvm.Building = BuildingsRepository.GetBuilding(building);
            return View(bvm);
        }
        [HttpPost]
        public ActionResult FroalaUploadImage(HttpPostedFileBase file, int? postId) // نام پارامتر فایل را تغییر ندهید
        {
            var fileName = Path.GetFileName(file.FileName);
            var rootPath = Server.MapPath("~/images/");
            file.SaveAs(Path.Combine(rootPath, fileName));
            return Json(new { link = "images/" + fileName }, JsonRequestBehavior.AllowGet);
        }
    }
}