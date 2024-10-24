using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public interface IToDoRepo
    {
        Task<IEnumerable<Entry>> GetAllAsync();
        Task<Entry> GetByIdAsync(Guid id);
        Task AddAsync(Entry item);
        Task UpdateAsync(Entry item);
        Task DeleteAsync(Guid id);
    }
    public class ToDoRepo : IToDoRepo
    {
        private readonly Context _context;

        public ToDoRepo(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entry>> GetAllAsync()
        {
            return await _context.ToDoList.ToListAsync();
        }

        public async Task<Entry> GetByIdAsync(Guid id)
        {
            return await _context.ToDoList.FindAsync(id);
        }

        public async Task AddAsync(Entry item)
        {
            _context.ToDoList.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entry item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.ToDoList.FindAsync(id);
            if (item != null)
            {
                _context.ToDoList.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
