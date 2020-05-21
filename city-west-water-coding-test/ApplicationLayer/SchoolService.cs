using city_west_water_coding_test.Configuration;
using city_west_water_coding_test.InfrastructureLayer;
using city_west_water_coding_test.InfrastructureLayer.SchoolDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace city_west_water_coding_test.ApplicationLayer
{
    public interface ISchoolService
    {
        Task<Result<int>> AddClass(ClassDto model);
        Task<Result> UpdateClass(ClassDto model);
        Task<Result> DeleteClass(int classId);
        Task<Result<ClassDto>> FindClass(int id);
        Task<Result<List<ClassDto>>> ListAllClasses();

        Task<Result<List<StudentDto>>> ListStudentByClass(int classId);
        Task<Result<int>> AddStudent(StudentDto model);
        Task<Result> UpdateStudent(StudentDto model);
        Task<Result> DeleteStudent(int studentId);
        Task<Result<StudentDto>> FindStudent(int id);
        Task<Result> EnrolInClass(int studentId, int classId);

        Task<Result<bool>> HasSameSurnameInClass(CheckStudentDto model);
    }
    /// <summary>
    /// School Service
    /// </summary>
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public SchoolService(ISchoolRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ClassDto>> FindClass(int id)
        {
            var result = new Result<ClassDto>();
            var entity = await _repository.FindClassById(id);
            result.Value = entity.ToModel();

            return result;
        }

        public async Task<Result<int>> AddClass(ClassDto model)
        {
            var result = new Result<int>();
            var entity = model.ToEntity();

            result.Value = await _repository.AddClass(entity);
            return result;
        }

        public async Task<Result> UpdateClass(ClassDto model)
        {
            var result = new Result();
            var entity = model.ToEntity();
            await _repository.UpdateClass(entity);
            return result;
        }

        public async Task<Result> DeleteClass(int classId)
        {
            var result = new Result();
            await _repository.DeleteClass(classId);
            return result;
        }

        public async Task<Result<List<ClassDto>>> ListAllClasses()
        {
            var result = new Result<List<ClassDto>>();
            var classes = await _repository.ListClass();
            result.Value = classes.Select(x => x.ToModel()).ToList();
            return result;
        }

        public async Task<Result<List<StudentDto>>> ListStudentByClass(int classId)
        {
            var result = new Result<List<StudentDto>>();
            var students = await _repository.ListStudentByClass(classId);
            result.Value = students.Select(x => x.ToModel()).OrderByDescending(x=>x.GPA).ToList();
            if (result.Value.Count > 0) result.Value[0].Highlighted = true;
            return result;
        }

        public async Task<Result<int>> AddStudent(StudentDto model)
        {
            var result = new Result<int>();
            var entity = model.ToEntity();

            result.Value = await _repository.AddStudent(entity);
            return result;
        }

        public async Task<Result> UpdateStudent(StudentDto model)
        {
            var result = new Result();
            var entity = model.ToEntity();

            await _repository.UpdateStudent(entity);

            return result;
        }

        public async Task<Result> DeleteStudent(int studentId)
        {
            var result = new Result();
            await _repository.DeleteStudent(studentId);

            return result;
        }

        public async Task<Result<StudentDto>> FindStudent(int id)
        {
            var result = new Result<StudentDto>();
            var entity = await _repository.FindStudentById(id);
            result.Value = entity.ToModel();
            result.Value.EnrolClass = entity.StudentClasses?.FirstOrDefault()?.ClassId;
            return result;
        }

        public async Task<Result> EnrolInClass(int studentId, int classId)
        {
            var result = new Result();
            var entity = new StudentClass()
            {
                StudentId = studentId,
                ClassId = classId
            };

            await _repository.AddStudentToClass(entity);

            return result;
        }

        public async Task<Result<bool>> HasSameSurnameInClass(CheckStudentDto model)
        {
            var result = new Result<bool>();
            var students = await _repository.ListStudentByClass(model.ClassId);
            var query = students.AsQueryable();
            if (model.StudentId.HasValue)
            {
                query = query.Where(x => x.LastName == model.Surname && x.Id != model.StudentId.Value);
            }
            else
            {
                query = query.Where(x => x.LastName == model.Surname);
            }
            var student = query.FirstOrDefault();
            result.Value = student == null ? false : true;
            return result;
        }

      
    }
}
