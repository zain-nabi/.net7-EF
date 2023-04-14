using Application.Model;
using Application.Interface;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class EventsRepository : IEvents
    {
        private readonly DataContext _context;
        public EventsRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(Events e)
        {
            _context.Entry(e).State = EntityState.Deleted;
        }

        public async Task<List<Events>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Events> GetEventById(int Id)
        {

            return await _context.Events.FindAsync(Id);
        }
        public bool Post(Events e)
        {
            _context.Events.Add(e);
            return true;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Put(Events e)
        {
            _context.Entry(e).State = EntityState.Modified;
        }
    }
}