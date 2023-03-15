using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvengersManagement.Services.AvengerService;
using Microsoft.AspNetCore.Mvc;

namespace AvengersManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvengerController : ControllerBase
    {
        private readonly IAvengerService _avengerService;

        public AvengerController(IAvengerService avengerService)
        {
            _avengerService = avengerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Avenger>>> GetAsync()
        {
            var result = await _avengerService.QueryAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Avenger>> GetAsync(int id)
        {
            var result = await _avengerService.ReadAsync(id);
            if(result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Avenger>> PostAsync(Avenger request)
        {
            var result = await _avengerService.CreateAsync(request);
            return CreatedAtAction("Get", new { id = request.Id }, request );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Avenger>> PutAsync(int id, Avenger request)
        {
            if(id != request.Id) return BadRequest();

            var result = await _avengerService.UpdateAsync(request);
            if(result is null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _avengerService.DeleteAsync(id);
            return NoContent();
        }



    }
}