using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using Model.Dtos;
using Model.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreApp.Api.Managers
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto> GetSubjectByIdAsync(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            return _mapper.Map<SubjectDto>(subject);
        }

        public async Task AddSubjectAsync(SubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            await _subjectRepository.AddAsync(subject);
        }

        public async Task UpdateSubjectAsync(int id, SubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            subject.SubjectId = id;
            await _subjectRepository.UpdateAsync(subject);
        }

        public async Task DeleteSubjectAsync(int id)
        {
            await _subjectRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsBySubjectAsync(int subjectId)
        {
            var students = await _subjectRepository.GetStudentsBySubjectIdAsync(subjectId);
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}