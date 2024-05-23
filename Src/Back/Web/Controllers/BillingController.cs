using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Web.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;
        private readonly IMapper _mapper;

        public BillingController(IBillingService billingService, IMapper mapper)
        {
            _billingService = billingService;
            _mapper = mapper;
        }

        // GET: api/<BillingController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var _billings = await _billingService.GetAllAsync();

            return _billings.Any() ? Ok(_billings) : NotFound();
        }

        // GET api/<BillingController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var _billing = await _billingService.GetByIdAsync(id);
            
            return _billing is null ? NotFound() : Ok(_billing);
        }

        // POST api/<BillingController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BillingRequest billing)
        {
            var _billing = _mapper.Map<Billing>(billing);
            await _billingService.AddAsync(_billing);

            return Ok(_billing);
        }

        // PUT api/<BillingController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BillingRequest billing)
        {
            var _billing = _mapper.Map<Billing>(billing);
            _billing = await _billingService.UpdateAsync(id, _billing);

            return _billing is null ? BadRequest() : Ok(_billing);
        }

        // DELETE api/<BillingController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var _billing = await _billingService.DeleteAsync(id);
            return _billing is null ? BadRequest() : Ok(_billing);
        }
    }
}
