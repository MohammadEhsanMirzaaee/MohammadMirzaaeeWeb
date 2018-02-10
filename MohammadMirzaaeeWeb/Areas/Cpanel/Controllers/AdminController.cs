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
        
        [HttpPost]
        public ActionResult DeleteCategory(Category category)
        {
            CategoriesRepository.Delete(category);
            return RedirectToAction("CategoriesList");
        }
        public ActionResult CategoriesList()
        {
            CategoryViewModel cvm = new CategoryViewModel();
            cvm.CategoriesList = CategoriesRepository.CategoriesList();
            return View(cvm);
        }
        public ActionResult AddBuilding()
        {
            var bvm = new BuildingViewModel();
            bvm.CategoriesList = CategoriesRepository.CategoriesList();
            return View(bvm);
        }

        [HttpPost]
        public ActionResult AddBuilding(Building building, HttpPostedFileBase file)
        {
            string pic = System.IO.Path.GetFileName(file.FileName);
            string path = System.IO.Path.Combine(
                                   Server.MapPath("~/images/main"), pic);
            file.SaveAs(path);
            building.ImageAddress = "/images/main/" + pic;
            BuildingViewModel bvm = new BuildingViewModel();
            BuildingsRepository.Add(building);
            bvm.EndUserMessage = "با موفقیت اضافه شد";
            bvm.CategoriesList = CategoriesRepository.CategoriesList();
            return View(bvm);
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

        public ActionResult UploadBuildingImages()
        {

            if (Request.Files["file"] != null)
            {
                HttpPostedFileBase MyFile = Request.Files["file"];

                // Setting location to upload files
                string TargetLocation = Server.MapPath("~/images/buildings/");

                try
                {
                    if (MyFile.ContentLength > 0)
                    {
                        // Get File Extension
                        string Extension = Path.GetExtension(MyFile.FileName);

                        // Determining file name. You can format it as you wish.
                        string FileName = Path.GetFileName(MyFile.FileName);
                        FileName = Guid.NewGuid().ToString().Substring(0, 8);

                        // Determining file size.
                        int FileSize = MyFile.ContentLength;

                        // Creating a byte array corresponding to file size.
                        byte[] FileByteArray = new byte[FileSize];

                        // Basic validation for file extension
                        string[] AllowedExtension = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };
                        string[] AllowedMimeType = { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" };

                        if (AllowedExtension.Contains(Extension) && AllowedMimeType.Contains(MimeMapping.GetMimeMapping(MyFile.FileName)))
                        {
                            // Posted file is being pushed into byte array.
                            MyFile.InputStream.Read(FileByteArray, 0, FileSize);

                            // Uploading properly formatted file to server.
                            MyFile.SaveAs(TargetLocation + FileName + Extension);
                            string json = "";
                            Hashtable resp = new Hashtable();
                            string urlPath = MapURL(TargetLocation) + FileName + Extension;

                            // Make the response an json object
                            resp.Add("link", urlPath);
                            json = JsonConvert.SerializeObject(resp);

                            // Clear and send the response back to the browser.
                            Response.Clear();
                            Response.ContentType = "application/json; charset=utf-8";
                            Response.Write(json);
                            Response.End();
                        }
                        else
                        {
                            // Handle validation errors
                        }
                    }
                }

                catch (Exception ex)
                {
                    // Handle errors
                }
            }
            return View();
        }
        private string MapURL(string path)
        {
            string appPath = Server.MapPath("/").ToLower();
            return string.Format("/{0}", path.ToLower().Replace(appPath, "").Replace(@"\", "/"));
        }
    }
}