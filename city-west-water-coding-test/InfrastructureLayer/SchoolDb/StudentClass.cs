using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace city_west_water_coding_test.InfrastructureLayer.SchoolDb
{
    public class StudentClass
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }
    }
}
