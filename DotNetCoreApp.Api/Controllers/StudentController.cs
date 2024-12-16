using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            await _studentService.AddStudentAsync(studentDto);
            return CreatedAtAction(nameof(GetStudentById), new { id = studentDto.StudentId }, studentDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            await _studentService.UpdateStudentAsync(id, studentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }

        [HttpGet("by-class/{classId}")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsByClass(int classId)
        {
            var students = await _studentService.GetStudentsByClassAsync(classId);
            return Ok(students);
        }

        [HttpGet("by-subject/{subjectId}")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsBySubject(int subjectId)
        {
            var students = await _studentService.GetStudentsBySubjectAsync(subjectId);
            return Ok(students);
        }
    }
}
