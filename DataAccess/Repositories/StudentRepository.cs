using Microsoft.EntityFrameworkCore;
using DataAccess.DBContexts;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                                 .Include(s => s.Class)
                                 .Include(s => s.Subjects)
                                 .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students
                                 .Include(s => s.Class)
                                 .Include(s => s.Subjects)
                                 .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetByClassIdAsync(int classId)
        {
            return await _context.Students
                                 .Where(s => s.ClassId == classId)
                                 .Include(s => s.Subjects)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetBySubjectIdAsync(int subjectId)
        {
            return await _context.Students
                                 .Where(s => s.Subjects.Any(sub => sub.SubjectId == subjectId))
                                 .Include(s => s.Class)
                                 .ToListAsync();
        }
    }
}
