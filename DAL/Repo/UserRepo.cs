using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : Repo, IRepo<User, int, User>, IAuth
    {
        public User Authenticate(string name, string password)
        {
            return db.Users.Where(x => x.Name.Equals(name) && x.Password.Equals(password)).SingleOrDefault();
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            var ex = Get(id);
            db.Users.Remove(ex);
            db.SaveChanges();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(u => u.Name.Equals(id));
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Update(User obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
