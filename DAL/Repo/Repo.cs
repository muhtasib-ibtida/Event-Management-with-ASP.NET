using System;
using DAL.EF;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class Repo
    {
        protected EMSContext db;

        internal Repo()
        {
            db = new EMSContext();
        }
    }
}
