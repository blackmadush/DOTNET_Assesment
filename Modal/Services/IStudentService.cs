using Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task AddStudentAsync(StudentDto studentDto);
        Task UpdateStudentAsync(int id, StudentDto studentDto);
        Task DeleteStudentAsync(int id);
        Task<IEnumerable<StudentDto>> GetStudentsByClassAsync(int classId);
        Task<IEnumerable<StudentDto>> GetStudentsBySubjectAsync(int subjectId);
    }
}