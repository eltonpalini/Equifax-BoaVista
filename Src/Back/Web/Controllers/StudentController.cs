using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Web.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;


        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var _students = await _studentService.GetAllAsync();
            return _students.Any() ? Ok(_students) : NotFound();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var _student = await _studentService.GetByIdAsync(id);
            return _student is null ? NotFound() : Ok(_student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentRequest student)
        {
            var _student = _mapper.Map<Student>(student);
            await _studentService.AddAsync(_student);

            return Ok(_student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentRequest student)
        {
            var _student = _mapper.Map<Student>(student);
            _student = await _studentService.UpdateAsync(id, _student);

            return _student is null ? BadRequest() : Ok(_student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var _student = await _studentService.DeleteAsync(id);
            return _student is null ? BadRequest() : Ok(_student);
        }
    }
}
