using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerScout.Data.Model;
using PlayerScout.Data.Repositories;

namespace PlayerScout.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ShortlistsController : ControllerBase
    {
        private readonly IGenericRepository<Shortlist> _shortlistsRepository;

        public ShortlistsController(IGenericRepository<Shortlist> shortlistsRepository)
        {
            _shortlistsRepository = shortlistsRepository;
        }

        // GET api/shortlists
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shortlists = await _shortlistsRepository.AllAsync();
            if (shortlists == null)
                return NotFound();

            return Ok(shortlists);
        }

        // GET api/shortlists/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var shortlist = await _shortlistsRepository.GetAsync(id);
            if (shortlist == null)
                return NotFound();

            return Ok(shortlist);
        }

        // POST api/shortlists
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shortlist shortlist)
        {
            var createdShortlist = await _shortlistsRepository.InsertAsync(shortlist);

            return Created(new Uri($"/api/shortlist/{createdShortlist.Id}", UriKind.Relative), createdShortlist);
        }

        // PUT api/shortlists/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Shortlist shortlist)
        {
            var existingShortlist = await _shortlistsRepository.GetAsync(id);
            if (existingShortlist == null)
                return NotFound();

            shortlist.Id = id;
            existingShortlist = await _shortlistsRepository.UpdateAsync(shortlist);

            return NoContent();
        }

        // DELETE api/shortlists/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deletedShortlist = await _shortlistsRepository.DeleteAsync(id);

            if (!deletedShortlist)
                return NotFound();

            return NoContent();
        }
    }
}
