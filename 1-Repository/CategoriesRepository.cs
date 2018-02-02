using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Repository
{
    public class CategoriesRepository : BaseRepository
    {
        public List<Category> CategoriesList()
        {
            return Context.Categories.ToList();
        }
        public void Add(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
        }
    }
}
