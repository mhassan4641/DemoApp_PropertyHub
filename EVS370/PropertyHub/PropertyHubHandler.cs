using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EVS370.PropertyHub
{
    public class PropertyHubHandler
    {
        public void AcceptAdv(PropertyAdv entity)
        {
            using(PropertyHubContext context=new PropertyHubContext())
            {
                context.Entry(entity.Status).State = EntityState.Unchanged;
                context.Update(entity);
                context.SaveChanges();
            }
        }
        public void RejectAdv(PropertyAdv entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(entity.Status).State = EntityState.Unchanged;
                context.Update(entity);
                context.SaveChanges();
            }
        }
        public PropertyAdv AddAdvertizement(PropertyAdv entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(entity.Status).State = EntityState.Unchanged;
                context.Entry(entity.Type).State = EntityState.Unchanged;
                context.Entry(entity.Neighborhood).State = EntityState.Unchanged;
                context.Entry(entity.PostedBy).State = EntityState.Unchanged;
                context.Entry(entity.Area.PropertyAreaUnit).State = EntityState.Unchanged;
                context.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public PropertyAdv GetAdvertizement(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                PropertyAdv found = (from adv in context.PropertyAdvs
                                        .Include(adv=>adv.Images)
                                        .Include(adv=>adv.Neighborhood.City.Province.Country)
                                        .Include(adv => adv.Area.PropertyAreaUnit)
                                        .Include(adv => adv.PostedBy.Role)
                                        .Include(adv => adv.Status)
                                        .Include(adv => adv.Type)
                                        where adv.Id == id
                                     select adv).FirstOrDefault();
                return found;
            }
        }

        public List<PropertyAdv> GetAdvertizements()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                List<PropertyAdv> result = (from adv in context.PropertyAdvs
                                        .Include(adv => adv.Images)
                                        .Include(adv => adv.Neighborhood.City.Province.Country)
                                        .Include(adv => adv.Area.PropertyAreaUnit)
                                        .Include(adv => adv.PostedBy)
                                        .Include(adv => adv.Status)
                                        .Include(adv => adv.Type)
                                     select adv).ToList();
                return result;
            }
        }
        public List<PropertyAdv> GetAcceptedAdvertizements()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                List<PropertyAdv> result = (from adv in context.PropertyAdvs
                                        .Include(adv => adv.Images)
                                        .Include(adv => adv.Neighborhood.City.Province.Country)
                                        .Include(adv => adv.Area.PropertyAreaUnit)
                                        .Include(adv => adv.PostedBy)
                                        .Include(adv => adv.Status)
                                        .Include(adv => adv.Type)
                                        where adv.Status.Id == 2
                                        select adv).ToList();
                return result;
            }
        }
        public List<PropertyAdv> GetPendingAdvertizements()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                List<PropertyAdv> result = (from adv in context.PropertyAdvs
                                        .Include(adv => adv.Images)
                                        .Include(adv => adv.Neighborhood.City.Province.Country)
                                        .Include(adv => adv.Area.PropertyAreaUnit)
                                        .Include(adv => adv.PostedBy)
                                        .Include(adv => adv.Status)
                                        .Include(adv => adv.Type)
                                         where adv.Status.Id == 1
                                         select adv).ToList();
                return result;
            }
        }

        public List<PropertyAreaUnit> GetPropertyAreaUnits()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                List<PropertyAreaUnit> result = (from u in context.PropertyAreaUnits
                                            select u).ToList();
                return result;
            }
        }

        public List<AdvType> GetAdvsTypes()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                List<AdvType> advTypes = (from t in context.AdvTypes
                                          select t).ToList();
                return advTypes;
            }
        }



        public List<Neighborhood> GetNeighborhoods()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                List<Neighborhood> areasList = (from a in context.Neighborhoods
                                            .Include(a => a.City.Province.Country)
                                        select a).ToList();
                return areasList;
            }
        }

        public Neighborhood GetNeighborhood(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                Neighborhood area = (from a in context.Neighborhoods
                                            .Include(a=>a.City.Province.Country)
                                        where a.Id == id
                                        select a).FirstOrDefault();
                return area;
            }
        }

        public List<Neighborhood> GetNeighborhoods(City city)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                List<Neighborhood> areasList = (from a in context.Neighborhoods
                                            .Include(a=>a.City.Province.Country)
                                        where a.City.Id == city.Id
                                        select a).ToList();
                return areasList;
            }
        }


        public Neighborhood AddNeighborhood(Neighborhood entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(entity.City).State = EntityState.Unchanged;
                context.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public Neighborhood UpdateNeighborhood(int id, Neighborhood area)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                Neighborhood found = context.Find<Neighborhood>(id);
                if (!string.IsNullOrWhiteSpace(area.Name))
                {
                    found.Name = area.Name;
                }
                if (area.City?.Id!= 0){
                    found.City = area.City;
                    context.Entry(found.City).State = EntityState.Unchanged;
                }
                found.Image = area.Image;
                context.SaveChanges();
                return found;
            }
        }

        public Neighborhood DeleteNeighborhood(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                Neighborhood found = context.Find<Neighborhood>(id);
                context.Remove(found);
                context.SaveChanges();
                return found;
            }
        }
    }
}
