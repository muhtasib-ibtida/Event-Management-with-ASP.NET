using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRSVPRepo
    {
        RSVP Create(RSVP obj);
        RSVP Update(RSVP obj);
        RSVP Get(int id);
        List<RSVP> Get();
        void Delete(int id);
    }
}
