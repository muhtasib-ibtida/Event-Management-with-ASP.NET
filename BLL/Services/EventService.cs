using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EventService
    {
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventDTO>();
                cfg.CreateMap<EventDTO, Event>();
            });
            return new Mapper(config);
        }

        public static List<EventDTO> Get()
        {
            var repo = DataAccessFactory.CreateEventRepo();
            var data = repo.Get();
            return GetMapper().Map<List<EventDTO>>(data);
        }

        public static EventDTO Get(int id)
        {
            var repo = DataAccessFactory.CreateEventRepo();
            var data = repo.Get(id);
            return GetMapper().Map<EventDTO>(data);
        }

        public static EventDTO Create(EventDTO obj)
        {
            var repo = DataAccessFactory.CreateEventRepo();
            var eventObj = GetMapper().Map<Event>(obj);
            var result = repo.Create(eventObj);
            return GetMapper().Map<EventDTO>(result);
        }

        public static EventDTO Update(EventDTO obj)
        {
            var repo = DataAccessFactory.CreateEventRepo();
            var eventObj = GetMapper().Map<Event>(obj);
            var result = repo.Update(eventObj);
            return GetMapper().Map<EventDTO>(result);
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.CreateEventRepo();
            repo.Delete(id);
            return true;
        }
    }
}
