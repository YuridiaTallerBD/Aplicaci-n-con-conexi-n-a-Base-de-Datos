using Microsoft.AspNetCore.Mvc;
using MariaAspNet.Models;
using MariaAspNet.Models.Contracts;
using System.Threading.Tasks;

namespace MariaAspNet.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public StudentController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _dataRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{nocontrol}", Name = "GetStudent")]
        public async Task<IActionResult> GetStudent(string nocontrol)
        {
            var student = await _dataRepository.GetAsync(nocontrol);
            if (student is null)
            {
                return NotFound("Student not found.");
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] StudentModel student)
        {
            if (student is null)
            {
                return BadRequest("Student is null.");
            }
            await _dataRepository.AddAsync(student);
            //return CreatedAtRoute("GetStudent", null, student);
            return Ok(student);
        }
        
        [HttpPut("{nocontrol}")]
        public async Task<IActionResult> PutStudent(string nocontrol, [FromBody] StudentModel student)
        {
            if (student is null)
            {
                return BadRequest("Student is null.");
            }
            var studentToUpdate = await _dataRepository.GetAsync(nocontrol);
            if (studentToUpdate is null)
            {
                return NotFound("The Student record couldn't be found.");
            }
            await _dataRepository.UpdateAsync(studentToUpdate, student);
            return NoContent();
        }

        [HttpDelete("{nocontrol}")]
        public async Task<IActionResult> DeleteStudent(string nocontrol)
        {
            var student = await _dataRepository.GetAsync(nocontrol);
            if (student is null)
            {
                return NotFound("The Student record couldn't be found.");
            }
            await _dataRepository.DeleteAsync(student);
            return NoContent();
        }
    }
}
