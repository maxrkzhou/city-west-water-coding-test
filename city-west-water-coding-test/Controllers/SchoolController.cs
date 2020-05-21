using city_west_water_coding_test.ApplicationLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace city_west_water_coding_test.Controllers
{
    /// <summary>
    /// School End point
    /// </summary>
    [Route("api/school")] 
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">School service</param>
        public SchoolController(ISchoolService service)
        {
            _service = service;
        }

        /// <summary>
        /// List all the classes
        /// </summary>
        /// <returns>list of classes</returns>
        [Route("class/list")]
        [HttpGet]
        public async Task<IActionResult> ListClass()
        {
            var result = await _service.ListAllClasses();

            return Ok(result);

        }

        /// <summary>
        /// Get class by id
        /// </summary>
        /// <returns>class dto</returns>
        [Route("class/{classId}")]
        [HttpGet]
        public async Task<IActionResult> GetClass([FromRoute] int classId)
        {
            var result = await _service.FindClass(classId);

            return Ok(result);

        }

        /// <summary>
        /// Add class
        /// </summary>
        /// <param name="model">Class Dto</param>
        /// <returns>Created class Id</returns>
        [Route("class/add")]
        [HttpPost]
        public async Task<IActionResult> AddClass(ClassDto model)
        {
            var result = await _service.AddClass(model);

            return Ok(result);
        }

        /// <summary>
        /// Update class information
        /// </summary>
        /// <param name="model">class model</param>
        /// <returns></returns>
        [Route("class/update")]
        [HttpPut]
        public async Task<IActionResult> UpdateClass(ClassDto model)
        {
            var result = await _service.UpdateClass(model);

            return Ok(result);
        }

        /// <summary>
        /// Delete class
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [Route("class/delete/{classId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteClass([FromRoute] int classId)
        {
            var result = await _service.DeleteClass(classId);

            return Ok(result);
        }

        /// <summary>
        /// List all the student who are enrolled in the class
        /// </summary>
        /// <param name="classId">Class Id</param>
        /// <returns>List of students</returns>
        [Route("class/{classId}/students")]
        [HttpGet]
        public async Task<IActionResult> ListStudentByClass(int classId)
        {
            var result = await _service.ListStudentByClass(classId);

            return Ok(result);
        }

        /// <summary>
        /// get student by id
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns>student dto</returns>
        [Route("student/{studentId}")]
        [HttpGet]
        public async Task<IActionResult> GetStudent([FromRoute] int studentId)
        {
            var result = await _service.FindStudent(studentId);

            return Ok(result);
        }

        /// <summary>
        /// Add student
        /// </summary>
        /// <param name="model">Student model</param>
        /// <returns>created student Id</returns>
        [Route("student/add")]
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDto model)
        {
            var result = await _service.AddStudent(model);
            return Ok(result);
        }

        /// <summary>
        /// Update student profile
        /// </summary>
        /// <param name="model">student profile</param>
        /// <returns></returns>
        [Route("student/update")]
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(StudentDto model)
        {
            var result = await _service.UpdateStudent(model);
            return Ok(result);
        }

        /// <summary>
        /// Delete student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [Route("student/delete/{studentId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent([FromRoute] int studentId)
        {
            var result = await _service.DeleteStudent(studentId);
            return Ok(result);
        }

        /// <summary>
        /// enrol class
        /// </summary>
        /// <param name="model">student class dto</param>
        /// <returns>result</returns>
        [Route("enrol-class")]
        [HttpPost]
        public async Task<IActionResult> EnrolClass(StudentClassDto model)
        {
            var result = await _service.EnrolInClass(model.StudentId, model.ClassId);

            return Ok(result);
        }

        /// <summary>
        /// Check is there a student with same surname enrol in the class
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        [Route("check-student")]
        [HttpPost]
        public async Task<IActionResult> HasSameSurnameInClass(CheckStudentDto model)
        {
            var result = await _service.HasSameSurnameInClass(model);

            return Ok(result);
        }
    }
}
