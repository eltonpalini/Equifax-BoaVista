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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var _courses = await _courseService.GetAllAsync();
            return _courses.Any() ? Ok(_courses) : NotFound();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var _course = await _courseService.GetByIdAsync(id);
            return _course is null ? NotFound() : Ok(_course);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseRequest course)
        {
            var _course = _mapper.Map<Course>(course);
            await _courseService.AddAsync(_course);

            return Ok(_course);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseRequest course)
        {
            var _course = _mapper.Map<Course>(course);
            _course = await _courseService.UpdateAsync(id, _course);

            return _course is null ? BadRequest() : Ok(_course);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var _course = await _courseService.DeleteAsync(id);
            return _course is null ? BadRequest() : Ok(_course);
        }
    }
}
