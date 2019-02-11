using Stefanini.Dao;
using Stefanini.Dtos;
using Stefanini.Models;
using Stefanini.Repository;
using Stefanini.serviceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stefanini.service
{
    public class CustomerService : ICustomerService
    {
        private CustomerRepository customerRepository;
        private GenderRepository genderRepository;
        private RegionRepository regionRepository;
        private SellerRepository sellerRepository;
        private ClassificationRepository classificationRepository;
        private CityRepository cityRepository;

        public CustomerService()
        {
            customerRepository = new CustomerDAO();
            genderRepository = new GenderDAO();
            regionRepository = new RegionDAO();
            sellerRepository = new SellerDAO();
            classificationRepository = new ClassificationDAO();
            cityRepository = new CityDAO();
        }

        public Customer[] getCustomers(CustomerFiltersDTO dto)
        {
            Customer[] customersArray = customerRepository.getCustomers(dto);

            return customersArray;
        }

        public City[] getCities(int regionId) {

            City[] cities = cityRepository.getCities(regionId);

            return cities;
        }

        public Gender[] getGenders() {

            Gender[] genders = genderRepository.getGenders();

            return genders;
        }

        public Region[] getRegions() {

            Region[] regions = regionRepository.getRegions();

            return regions;
        }

        public UserSys[] getSellers() {

            UserSys[] sellers = sellerRepository.getSellers();

            return sellers;
        }

        public Classification[] getClassifications()
        {

            Classification[] classifications = classificationRepository.getClassifications();

            return classifications;
        }
    }
}