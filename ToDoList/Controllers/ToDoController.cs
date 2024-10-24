using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Data;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IToDoRepo _repository;

        public TodoController(IToDoRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> GetTodos()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> GetEntry(Guid id)
        {
            var Entry = await _repository.GetByIdAsync(id);
            if (Entry == null)
            {
                return NotFound();
            }

            return Ok(Entry);
        }

        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(Entry Entry)
        {
            await _repository.AddAsync(Entry);
            return CreatedAtAction(nameof(GetEntry), new { id = Entry.Id }, Entry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntry(Guid id, Entry Entry)
        {
            if (id != Entry.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync(Entry);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
