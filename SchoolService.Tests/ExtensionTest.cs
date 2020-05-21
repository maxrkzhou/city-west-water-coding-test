using city_west_water_coding_test.ApplicationLayer;
using city_west_water_coding_test.InfrastructureLayer.SchoolDb;
using System;
using Xunit;

namespace SchoolService.Tests
{
    public class ExtensionTest
    {
        [Fact]
        public void Test_StudentDtoToEntity_ShouldReturnCorrectTypeAndValue()
        {
            var dto = new StudentDto()
            {
                Id = 1,
                FirstName = "Max",
                LastName = "Zhou",
                Age = 20,
                GPA = 3.5d
            };

            var actualResult = dto.ToEntity();

            Assert.IsType<Student>(actualResult);
            Assert.Equal(1, actualResult.Id);
            Assert.Equal("Max", actualResult.FirstName);
            Assert.Equal("Zhou", actualResult.LastName);
            Assert.Equal(3.5d, actualResult.GPA);
            Assert.Equal(20, actualResult.Age);
        }

        [Fact]
        public void Test_StudentToModel_ShouldReturnCorrectTypeAndValue()
        {
            var entity = new Student()
            {
                Id = 1,
                FirstName = "Max",
                LastName = "Zhou",
                Age = 20,
                GPA = 3.5d
            };

            var actualResult = entity.ToModel();

            Assert.IsType<StudentDto>(actualResult);
            Assert.Equal(1, actualResult.Id);
            Assert.Equal("Max", actualResult.FirstName);
            Assert.Equal("Zhou", actualResult.LastName);
            Assert.Equal(3.5d, actualResult.GPA);
            Assert.Equal(20, actualResult.Age);
        }

        [Fact]
        public void Test_ClassDtoToEntity_ShouldReturnCorrectTypeAndValue()
        {
            var dto = new ClassDto()
            {
                Id = 1,
                Name = "Class Name",
                Location = "Location",
                Teacher = "Teacher"
            };

            var actualResult = dto.ToEntity();

            Assert.IsType<Class>(actualResult);
            Assert.Equal(1, actualResult.Id);
            Assert.Equal("Class Name", actualResult.Name);
            Assert.Equal("Location", actualResult.Location);
            Assert.Equal("Teacher", actualResult.Teacher);
        }

        [Fact]
        public void Test_ClassToModel_ShouldReturnCorrectTypeAndValue()
        {
            var entity = new Class()
            {
                Id = 1,
                Name = "Class Name",
                Location = "Location",
                Teacher = "Teacher"
            };

            var actualResult = entity.ToModel();

            Assert.IsType<ClassDto>(actualResult);
            Assert.Equal(1, actualResult.Id);
            Assert.Equal("Class Name", actualResult.Name);
            Assert.Equal("Location", actualResult.Location);
            Assert.Equal("Teacher", actualResult.Teacher);
        }
    }
}
