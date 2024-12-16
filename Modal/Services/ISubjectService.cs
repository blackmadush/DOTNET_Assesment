using Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto> GetSubjectByIdAsync(int id);
        Task AddSubjectAsync(SubjectDto subjectDto);
        Task UpdateSubjectAsync(int id, SubjectDto subjectDto);
        Task DeleteSubjectAsync(int id);
        Task<IEnumerable<StudentDto>> GetStudentsBySubjectAsync(int subjectId);
    }
}