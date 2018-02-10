using _1_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MohammadMirzaaeeWeb.Models
{
    public class BuildingViewModel : BaseResponse
    {
        public List<Building> BuildingsList { get; set; }
        public Building Building { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public List<Category> CategoriesList { get; set; }
    }
}