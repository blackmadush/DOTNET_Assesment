using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDto>>> GetAllClasses()
        {
            var classes = await _classService.GetAllClassesAsync();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDto>> GetClassById(int id)
        {
            ClassDto classVariable = await _classService.GetClassByIdAsync(id); //don't use @class as variable name
            if (classVariable == null)
                return NotFound();

            return Ok(classVariable);
        }

        [HttpPost]
        public async Task<ActionResult> AddClass([FromBody] ClassDto classDto)
        {
            await _classService.AddClassAsync(classDto);
            return CreatedAtAction(nameof(GetClassById), new { id = classDto.ClassId }, classDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClass(int id, [FromBody] ClassDto classDto)
        {
            await _classService.UpdateClassAsync(id, classDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClass(int id)
        {
            await _classService.DeleteClassAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/students")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsInClass(int id)
        {
            var students = await _classService.GetStudentsInClassAsync(id);
            return Ok(students);
        }
    }
}
