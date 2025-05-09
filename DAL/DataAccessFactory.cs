using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DataAccessFactory
    {
        public static IAuth CreateAuthRepo()
        {
            return new UserRepo();
        }

        public static IRepo<Event, int, Event> CreateEventRepo()
        {
            return new EventRepo();
        }

        public static IRepo<RSVP, int, RSVP> CreateRSVPRepo()
        {
            return new RSVPRepo();
        }

        public static IRepo<User, int, User> CreateUserRepo()
        {
            return new UserRepo();
        }
    }
}
