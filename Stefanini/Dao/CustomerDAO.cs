using Stefanini.Data;
using Stefanini.Dtos;
using Stefanini.Models;
using Stefanini.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Stefanini.Dao
{
    public class CustomerDAO : CustomerRepository
    {
        private StefaniniContext db;

        public CustomerDAO() {
            db = new StefaniniContext();
        }

        public Customer[] getCustomers(CustomerFiltersDTO dto)
        {
            bool isNotUserAdmin = (!dto.isUserAdmin);

            IQueryable<Customer> query = db.Set<Customer>().Include("Classification")
                                                             .Include("City")
                                                             .Include("Gender")
                                                             .Include("UserSys");
            query = getCustomerFilters(query, dto);
            Customer[] customersArray = query.ToArray();

            List<Customer> customerList = new List<Customer>();
            foreach (Customer c in customersArray) {
                Region region = db.Region.Single(r => r.id == c.city.regionId);
                c.city.region = region;                

                if (isNotUserAdmin)
                    c.userSys = null;

                customerList.Add(c);                
            }

            return customerList.ToArray();
        }

        private IQueryable<Customer> getCustomerFilters(IQueryable<Customer> query, CustomerFiltersDTO dto) {

            bool isNotUserAdmin = (!dto.isUserAdmin);

            if (isNotUserAdmin)
                query = query.Where(c => c.userId == dto.userId);

            if (dto.name != null && dto.name.Trim().Length > 0)
                query = query.Where(c => c.name.Contains(dto.name));

            if(dto.genderId != 0)
                query = query.Where(c => c.genderId == dto.genderId);

            if (dto.regionId != 0)
                query = query.Where(c => c.city.regionId == dto.regionId);

            if (dto.cityId != 0)
                query = query.Where(c => c.cityId == dto.cityId);

            if (dto.sellerId != 0)
                query = query.Where(c => c.userId == dto.sellerId);

            if(dto.classificationId != 0)
                query = query.Where(c => c.classificationId == dto.classificationId);

            if (dto.lastPurchaseBegin != DateTime.MinValue && dto.lastPurchaseEnd != DateTime.MinValue)
                query = query.Where(c => c.lastPurchase >= dto.lastPurchaseBegin && c.lastPurchase <= dto.lastPurchaseEnd);
            else if(dto.lastPurchaseBegin != DateTime.MinValue)
                query = query.Where(c => c.lastPurchase == dto.lastPurchaseBegin);
            else if(dto.lastPurchaseEnd != DateTime.MinValue)
                query = query.Where(c => c.lastPurchase == dto.lastPurchaseEnd);

            return query;
        }
    }
}