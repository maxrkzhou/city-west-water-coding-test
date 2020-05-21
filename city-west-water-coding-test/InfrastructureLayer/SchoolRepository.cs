using city_west_water_coding_test.InfrastructureLayer.SchoolDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace city_west_water_coding_test.InfrastructureLayer
{
    public interface ISchoolRepository
    {
        Task<Class> FindClassById(int id);
        Task<int> AddClass(Class entity);
        Task UpdateClass(Class entity);
        Task DeleteClass(int classId);
        Task<List<Class>> ListClass();

        Task<Student> FindStudentById(int studentId);
        Task<int> AddStudent(Student entity);
        Task UpdateStudent(Student entity);
        Task DeleteStudent(int studentId);

        Task<List<Student>> ListStudentByClass(int classId);

        Task AddStudentToClass(StudentClass entity);
    }
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolDbContext _context;
        public SchoolRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Class> FindClassById(int id)
        {
            return await _context.Class.FindAsync(id);
        }

        public async Task<int> AddClass(Class entity)
        {
            _context.Class.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateClass(Class entity)
        {
            _context.Class.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClass(int classId)
        {
            var entity = await _context.Class.FindAsync(classId);

            _context.Class.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Class>> ListClass()
        {
            return await _context.Class.ToListAsync();
        }

        public async Task<int> AddStudent(Student entity)
        {
            _context.Student.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateStudent(Student entity)
        {
            _context.Student.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int studentId)
        {
            var entity = await _context.Student.FindAsync(studentId);
            _context.Student.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> ListStudentByClass(int classId)
        {
            var query = _context.StudentClass.Where(x => x.ClassId == classId)
                        .Select(x => x.Student);

            return await query.ToListAsync();
        }

        public async Task<Student> FindStudentById(int studentId)
        {
            return await _context.Student.Include(x => x.StudentClasses).Where(x=>x.Id == studentId).FirstOrDefaultAsync();
        }

        public async Task AddStudentToClass(StudentClass entity)
        {
            var c = await _context.StudentClass.Where(x => x.StudentId == entity.StudentId).ToListAsync();
            _context.StudentClass.RemoveRange(c);
            _context.StudentClass.Add(entity);
            await _context.SaveChangesAsync();
        }
      
    }
}
