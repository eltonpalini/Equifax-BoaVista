using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Web.Requests;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return users.Any() ? Ok(users) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequest user)
        {
            var _user = _mapper.Map<User>(user);
            await _userService.AddAsync(_user);

            return Ok(_user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserRequest user)
        {
            var _user = _mapper.Map<User>(user);
            _user = await _userService.UpdateAsync(id, _user);

            return _user is null ? BadRequest() : Ok(_user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var _user = await _userService.DeleteAsync(id);

            return _user is null ? BadRequest() : Ok(_user);
        }
    }
}
