using _1_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Business
{
    public class CategoryLogic
    {
        CategoriesRepository CategoriesRepository;
        public CategoryLogic()
        {
            CategoriesRepository = new CategoriesRepository();
        }
        public List<Category> CategoriesList()
        {
            return CategoriesRepository.CategoriesList();
        }
    }
}
