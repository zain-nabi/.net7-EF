using Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IEvents
    {
        bool Post(Events e);
        void Put(Events e);
        Task<Events> GetEventById(int Id);
        Task<List<Events>> GetAllEvents();
        void Delete(Events e);
        Task<bool> SaveAllAsync();
    }
}
