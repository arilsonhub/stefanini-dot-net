using Stefanini.Data;
using Stefanini.Models;
using Stefanini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.Dao
{
    public class GenderDAO : GenderRepository
    {
        private StefaniniContext db;

        public GenderDAO()
        {
            db = new StefaniniContext();
        }

        public Gender[] getGenders()
        {
            Gender[] genders = db.Gender.ToArray();

            return genders;
        }
    }
}