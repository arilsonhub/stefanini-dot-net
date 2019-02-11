using Stefanini.Data;
using Stefanini.Models;
using Stefanini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.Dao
{
    public class UserSysDAO : UserSysRepository
    {
        private StefaniniContext db;

        public UserSysDAO() {
            db = new StefaniniContext();
        }

        public UserSys getUserByLoginAndPassword(string email, string password)
        {
            UserSys userLogged = db.UserSys.Include("UserRole").FirstOrDefault(u => u.email == email && u.password == password);
            return userLogged;
        }
    }
}