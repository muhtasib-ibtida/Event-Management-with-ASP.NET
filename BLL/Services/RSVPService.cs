using AutoMapper;
using DAL.EF;
using DAL;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RSVPService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RSVP, RSVPDTO>();
                cfg.CreateMap<RSVPDTO, RSVP>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Event, EventDTO>();
            });
            return new Mapper(config);
        }

        public static RSVPDTO CreateOrUpdateRSVP(int UserId,int eventId, string userName, bool status)
        {
            var repo = DataAccessFactory.CreateRSVPRepo();
            var userRepo = DataAccessFactory.CreateUserRepo();
            var eventRepo = DataAccessFactory.CreateEventRepo();

            var user = userRepo.Get(UserId);
            var eventDetails = eventRepo.Get(eventId);

            if (user == null || eventDetails == null)
            {
                return null;
            }

            var existingRSVP = repo.Get(eventId);

            if (existingRSVP != null)
            {
                existingRSVP.IsAttending = status;
                repo.Update(existingRSVP);
                return GetMapper().Map<RSVPDTO>(existingRSVP);
            }
            else
            {
                var newRSVP = new RSVP
                {
                    EventId = eventId,
                    UserId = user.Id,
                    IsAttending = status
                };

                var createdRSVP = repo.Create(newRSVP);
                return GetMapper().Map<RSVPDTO>(createdRSVP);
            }
        }

        public static List<RSVPDTO> GetRSVPsForEvent(int eventId)
        {
            var repo = DataAccessFactory.CreateRSVPRepo();
            var data = repo.Get(eventId);
            return GetMapper().Map<List<RSVPDTO>>(data);
        }

        public static RSVPDTO GetRSVPForUser(int eventId, int Id)
        {
            var repo = DataAccessFactory.CreateRSVPRepo();
            var userRepo = DataAccessFactory.CreateUserRepo();
            var user = userRepo.Get(Id);

            if (user == null)
            {
                return null;
            }

            var rsvp = repo.Get(eventId);
            return rsvp != null ? GetMapper().Map<RSVPDTO>(rsvp) : null;
        }
    }
}
