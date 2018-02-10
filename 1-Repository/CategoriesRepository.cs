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
        public void Delete(Category category)
        {
            var rqResult = Context.Categories.Where(x => x.CategoryID == category.CategoryID).SingleOrDefault();
            Context.Entry(rqResult).State = System.Data.Entity.EntityState.Deleted;
            var rqBuildings = Context.Buildings.Where(x => x.CategoryRefID == category.CategoryID).ToList();
            foreach(var b in rqBuildings)
            {
                Context.Entry(b).State = System.Data.Entity.EntityState.Deleted;
            }
            Context.SaveChanges();
        }
    }
}
