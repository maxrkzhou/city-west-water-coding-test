using city_west_water_coding_test.InfrastructureLayer.SchoolDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace city_west_water_coding_test.ApplicationLayer
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Teacher { get; set; }
    }

    public static class ClassDtoExtension
    {
        public static ClassDto ToModel(this Class entity)
        {
            var model = new ClassDto();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Teacher = entity.Teacher;
            model.Location = entity.Location;

            return model;
        }

        public static Class ToEntity(this ClassDto model)
        {
            var entity = new Class();
            entity.Id = model.Id;
            entity.Location = model.Location;
            entity.Name = model.Name;
            entity.Teacher = model.Teacher;

            return entity;
        }
    }
}
