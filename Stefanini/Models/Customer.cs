using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stefanini.Models
{
    public class Customer
    {
        public int id { get; set; }
        public String name { get; set; }
        public String phone { get; set; }
        public int genderId { get; set; }
        public Gender gender { get; set; }
        public int cityId { get; set; }
        public City city { get; set; }        
        [DataType(DataType.Date)]
        public DateTime lastPurchase { get; set; }
        public int classificationId { get; set; }
        public Classification classification { get; set; }
        public int userId { get; set; }
        public UserSys userSys { get; set; }
    }
}