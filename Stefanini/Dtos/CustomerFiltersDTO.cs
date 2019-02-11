using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.Dtos
{
    public class CustomerFiltersDTO
    {
        public bool isUserAdmin { get; set; }
        public int userId { get; set; }
        public String name { get; set; }
        public int cityId { get; set; }
        public DateTime lastPurchaseBegin { get; set; }
        public DateTime lastPurchaseEnd { get; set; }
        public int classificationId { get; set; }
        public int genderId { get; set; }
        public int regionId { get; set; }
        public int sellerId { get; set; }        
    }
}