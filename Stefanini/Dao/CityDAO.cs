using Stefanini.Data;
using Stefanini.Models;
using Stefanini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.Dao
{
    public class CityDAO : CityRepository
    {
        private StefaniniContext db;

        public CityDAO()
        {
            db = new StefaniniContext();
        }

        public City[] getCities(int regionId)
        {
            City[] cities = db.City.Where(c => c.regionId == regionId).ToArray();
            return cities;
        }
    }
}