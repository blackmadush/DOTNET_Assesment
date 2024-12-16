using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student  student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<IEnumerable<Student>> GetByClassIdAsync(int classId);
        Task<IEnumerable<Student>> GetBySubjectIdAsync(int subjectId);
    }
}
