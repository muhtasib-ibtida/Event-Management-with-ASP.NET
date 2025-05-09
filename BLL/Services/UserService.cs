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
    public class UserService
    {
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            return new Mapper(config);
        }

        public static List<UserDTO> Get()
        {
            var repo = DataAccessFactory.CreateUserRepo();
            var data = repo.Get();
            return GetMapper().Map<List<UserDTO>>(data);
        }

        public static UserDTO Get(int id)
        {
            var repo = DataAccessFactory.CreateUserRepo();
            var data = repo.Get(id);
            return GetMapper().Map<UserDTO>(data);
        }

        public static UserDTO Create(UserDTO obj)
        {
            var repo = DataAccessFactory.CreateUserRepo();
            var userObj = GetMapper().Map<User>(obj);
            var result = repo.Create(userObj);
            return GetMapper().Map<UserDTO>(result);
        }

        public static UserDTO Update(UserDTO obj)
        {
            var repo = DataAccessFactory.CreateUserRepo();
            var userObj = GetMapper().Map<User>(obj);
            var result = repo.Update(userObj);
            return GetMapper().Map<UserDTO>(result);
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.CreateUserRepo();
            repo.Delete(id);
            return true;
        }
    }
}
