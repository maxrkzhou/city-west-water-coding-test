using city_west_water_coding_test.InfrastructureLayer.SchoolDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace city_west_water_coding_test.ApplicationLayer
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
        public int? EnrolClass { get; set; }
        public bool Highlighted { get; set; }
    }

    public static class StudentDtoExtension
    {
        public static StudentDto ToModel(this Student entity)
        {
            return new StudentDto() {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                GPA = entity.GPA
            };
        }

        public static Student ToEntity(this StudentDto model)
        {
            var entity = new Student();
            entity.Id = model.Id;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Age = model.Age;
            entity.GPA = model.GPA;

            return entity;
        }
    }
}
