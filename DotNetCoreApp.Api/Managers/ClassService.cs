using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using Model.Dtos;
using Model.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreApp.Api.Managers
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassService(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassDto>> GetAllClassesAsync()
        {
            var classes = await _classRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClassDto>>(classes);
        }

        public async Task<ClassDto> GetClassByIdAsync(int id)
        {
            var @class = await _classRepository.GetByIdAsync(id);
            return _mapper.Map<ClassDto>(@class);
        }

        public async Task AddClassAsync(ClassDto classDto)
        {
            var @class = _mapper.Map<Class>(classDto);
            await _classRepository.AddAsync(@class);
        }

        public async Task UpdateClassAsync(int id, ClassDto classDto)
        {
            var @class = _mapper.Map<Class>(classDto);
            @class.ClassId = id;
            await _classRepository.UpdateAsync(@class);
        }

        public async Task DeleteClassAsync(int id)
        {
            await _classRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsInClassAsync(int classId)
        {
            var students = await _classRepository.GetStudentsByClassIdAsync(classId);
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}