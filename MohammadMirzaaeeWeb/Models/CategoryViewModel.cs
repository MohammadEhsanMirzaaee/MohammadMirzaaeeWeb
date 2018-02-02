using _1_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MohammadMirzaaeeWeb.Models
{
    public class CategoryViewModel : BaseResponse
    {
        public List<Category> CategoriesList { get; set; }
        public Category Category { get; set; }
    }
}