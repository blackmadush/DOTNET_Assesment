using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using Model.Dtos;
using Model.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreApp.Api.Managers
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task AddStudentAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(int id, StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            student.StudentId = id;
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsByClassAsync(int classId)
        {
            var students = await _studentRepository.GetByClassIdAsync(classId);
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsBySubjectAsync(int subjectId)
        {
            var students = await _studentRepository.GetBySubjectIdAsync(subjectId);
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}
