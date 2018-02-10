using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Repository
{
    public class BuildingsRepository : BaseRepository
    {
        public void Add(Building building)
        {
            Context.Buildings.Add(building);
            Context.SaveChanges();
        }
        public List<Building> BuldingsListById(Category category)
        {
            return Context.Buildings.Where(x => x.CategoryRefID == category.CategoryID).ToList();
        }

        public Building GetBuilding(Building building)
        {
            return Context.Buildings.Where(x => x.BuildingID == building.BuildingID).SingleOrDefault();
        }
    }
}
