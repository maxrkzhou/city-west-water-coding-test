using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace city_west_water_coding_test.InfrastructureLayer.SchoolDb
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Teacher { get; set; }

        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
