using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Repository
{
    public class BaseRepository
    {
        public Context Context;
        public BaseRepository()
        {
            Context = new Context();
        }
    }
}
