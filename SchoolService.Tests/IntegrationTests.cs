using city_west_water_coding_test.ApplicationLayer;
using city_west_water_coding_test.InfrastructureLayer;
using city_west_water_coding_test.InfrastructureLayer.SchoolDb;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolService.Tests
{
    public class IntegrationTests
    {
        private readonly ISchoolRepository _repository;
        private readonly ISchoolService _service;
        public IntegrationTests()
        {
            var mock = new Mock<ISchoolRepository>();
            mock.Setup(x => x.FindClassById(It.IsAny<int>())).ReturnsAsync(new Class()
            {
                Id = 1,
                Name = "Class Name",
                Location = "Location",
                Teacher = "Teacher"
            });

            mock.Setup(x => x.FindStudentById(It.IsAny<int>())).ReturnsAsync(new Student()
            {
                Id = 1,
                FirstName = "Max",
                LastName = "Zhou",
                Age = 20,
                GPA = 3.5d
            });
            _service = new city_west_water_coding_test.ApplicationLayer.SchoolService(mock.Object);
        }

        [Fact]
        public async Task Test_FindClass_CorrectClassShouldBeReturned()
        {
            var actualResult = await _service.FindClass(1);

            Assert.True(actualResult.IsSuccess);
            Assert.Equal(1, actualResult.Value.Id);
            Assert.Equal("Location", actualResult.Value.Location);
            Assert.Equal("Teacher", actualResult.Value.Teacher);

        }

        [Fact]
        public async Task Test_FindStudent_CorrectStudentShouldBeReturned()
        {
            var actualResult = await _service.FindStudent(1);

            Assert.True(actualResult.IsSuccess);
            Assert.Equal(1, actualResult.Value.Id);
            Assert.Equal("Max", actualResult.Value.FirstName);
            Assert.Equal("Zhou", actualResult.Value.LastName);
            Assert.Equal(20, actualResult.Value.Age);
            Assert.Equal(3.5d, actualResult.Value.GPA);
        }
    }
}
