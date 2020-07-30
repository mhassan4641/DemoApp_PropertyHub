using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVS370
{
    public class LocationsHandler
    {
        public City GetCity(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {

                return (from c in context.Cities
                            .Include(c => c.Province.Country)
                        where id == c.Id
                        select c).FirstOrDefault();
            }
        }
        public List<City> GetCities()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities
                        .Include(c => c.Province.Country)
                        select c).ToList();
            }
        }
        public List<City> GetCities(Country country)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities
                        .Include(c => c.Province.Country)
                        where c.Province.Country.Id == country.Id
                        select c).ToList();
            }
        }
        public List<City> GetCities(Province province)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities
                        .Include(c => c.Province.Country)
                        where c.Province.Id == province.Id
                        select c).ToList();
            }
        }
        public List<Province> GetProvinces(Country country)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from p in context.Provinces
                        .Include(p => p.Country)
                        where p.Country.Id == country.Id
                        select p).ToList();
            }
        }
        public City AddCity(City city)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(city.Province).State = EntityState.Unchanged;
                context.Add(city);
                context.SaveChanges();
            }
            return city;
        }
        public City UpdateCity(int idToSearch, City city)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(city.Province).State = EntityState.Unchanged;
                City found = context.Find<City>(idToSearch);
                found.Name = (!string.IsNullOrWhiteSpace(city.Name)) ? city.Name : found.Name;
                found.Province = (city.Province != null && city.Province.Id > 0) ? city.Province : found.Province;
                context.SaveChanges();
                return found;
            }
        }
        public City DeleteCity(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                City found = context.Find<City>(id);
                context.Remove(found);
                context.SaveChanges();
                return found;
            }
        }
        public Province AddProvince(Province province)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(province.Country).State = EntityState.Unchanged;
                context.Add(province);
                context.SaveChanges();
            }
            return province;
        }
        public Country GetCountry(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Countries
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
        public List<Country> GetCountries()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Countries
                        select c).ToList();
            }
        }
        
        public Country AddCountry(Country country)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Add(country);
                context.SaveChanges();
            }
            return country;
        }
        public Country UpdateCountry(int idToSearch, Country country)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                Country found = context.Find<Country>(idToSearch);
                //context.Update(country);
                if (!string.IsNullOrWhiteSpace(country.Name))
                {
                    found.Name = country.Name;
                }
                if (country.Code != null && country.Code > 0)
                {
                    found.Code = country.Code;
                }
                context.SaveChanges();
                return found;
            }
        }
        public Country DeleteCountry(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                Country found = context.Find<Country>(id);
                context.Remove(found);
                context.SaveChanges();
                return found;
            }
        }




    }
}
