using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class RSVPRepo : Repo, IRepo<RSVP, int, RSVP>
    {
        public RSVP Create(RSVP obj)
        {
            db.RSVPs.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            var ex = Get(id);
            db.RSVPs.Remove(ex);
            db.SaveChanges();
        }

        public RSVP Get(int id)
        {
            return db.RSVPs.Find(id);
        }

        public List<RSVP> Get()
        {
            return db.RSVPs.ToList();
        }

        public RSVP Update(RSVP obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
