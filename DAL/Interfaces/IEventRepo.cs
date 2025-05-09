using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEventRepo
    {
        Event Create(Event obj);
        Event Update(Event obj);
        Event Get(int id);
        List<Event> Get();
        void Delete(int id);
    }
}
