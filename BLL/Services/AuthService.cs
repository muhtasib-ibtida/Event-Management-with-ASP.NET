using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            return new Mapper(config);
        }

        public static UserDTO Authenticate(string name, string password)
        {
            var authRepo = DataAccessFactory.CreateAuthRepo();
            var user = authRepo.Authenticate(name, password);

            if (user != null)
            {
                return GetMapper().Map<UserDTO>(user);
            }

            return null;
        }
        public static UserDTO Register(UserDTO userDTO)
        {
            var repo = DataAccessFactory.CreateUserRepo();
            var user = GetMapper().Map<User>(userDTO);
            var createdUser = repo.Create(user);
            return GetMapper().Map<UserDTO>(createdUser);
        }
    }
}
