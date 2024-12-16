using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllAsync();
        Task<Class> GetByIdAsync(int id);
        Task AddAsync(Class @class);
        Task UpdateAsync(Class @class);
        Task DeleteAsync(int id);
        Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId);
    }
}
