using Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model.Services
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDto>> GetAllClassesAsync();
        Task<ClassDto> GetClassByIdAsync(int id);
        Task AddClassAsync(ClassDto classDto);
        Task UpdateClassAsync(int id, ClassDto classDto);
        Task DeleteClassAsync(int id);
        Task<IEnumerable<StudentDto>> GetStudentsInClassAsync(int classId);
    }
}