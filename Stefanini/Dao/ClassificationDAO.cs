using Stefanini.Data;
using Stefanini.Models;
using Stefanini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.Dao
{
    public class ClassificationDAO : ClassificationRepository
    {
        private StefaniniContext db;

        public ClassificationDAO()
        {
            db = new StefaniniContext();
        }

        public Classification[] getClassifications()
        {
            Classification[] classifications = db.Classification.ToArray();

            return classifications;
        }
    }
}