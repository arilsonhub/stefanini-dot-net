using Stefanini.Data;
using Stefanini.Models;
using Stefanini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.Dao
{
    public class SellerDAO : SellerRepository
    {
        private StefaniniContext db;

        public SellerDAO()
        {
            db = new StefaniniContext();
        }
        public UserSys[] getSellers()
        {
            UserSys[] sellers = db.UserSys.Where(u => u.userRole.isAdmin == false).ToArray();

            return sellers;
        }
    }
}