using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class EventRepo : Repo, IRepo<Event, int, Event>
    {
        public Event Create(Event obj)
        {
            db.Events.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            var ex = Get(id);
            db.Events.Remove(ex);
            db.SaveChanges();
        }

        public Event Get(int id)
        {
            return db.Events.Find(id);
        }

        public List<Event> Get()
        {
            return db.Events.ToList();
        }

        public Event Update(Event obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
