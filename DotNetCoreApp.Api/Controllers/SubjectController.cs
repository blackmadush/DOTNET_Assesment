using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
                return NotFound();

            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult> AddSubject([FromBody] SubjectDto subjectDto)
        {
            await _subjectService.AddSubjectAsync(subjectDto);
            return CreatedAtAction(nameof(GetSubjectById), new { id = subjectDto.SubjectId }, subjectDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubject(int id, [FromBody] SubjectDto subjectDto)
        {
            await _subjectService.UpdateSubjectAsync(id, subjectDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            await _subjectService.DeleteSubjectAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/students")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsBySubject(int id)
        {
            var students = await _subjectService.GetStudentsBySubjectAsync(id);
            return Ok(students);
        }
    }
}
