using Stefanini.Data;
using Stefanini.Models;
using Stefanini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.Dao
{
    public class RegionDAO : RegionRepository
    {
        private StefaniniContext db;

        public RegionDAO()
        {
            db = new StefaniniContext();
        }
        public Region[] getRegions()
        {
            Region[] regions = db.Region.ToArray();

            return regions;
        }
    }
}