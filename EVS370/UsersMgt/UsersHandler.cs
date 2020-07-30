using EVS370.UsersMgt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVS370
{
    public class UsersHandler
    {
        public void signup(User entity)
        {
            using(PropertyHubContext context=new PropertyHubContext())
            {
                context.Entry(entity.Role).State = EntityState.Unchanged;
                context.Add(entity);
                context.SaveChanges();
            }
        }
        public List<User> GetUsers()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")
                        select u).ToList();
            }
        }

        public User GetUser(string loginid, string password)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")
                        where u.LoginId.Equals(loginid) && u.Password.Equals(password)
                        select u).FirstOrDefault();
            }
        }

        public User GetUser(string apikey)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")
                        where u.ApiKey.Equals(apikey)
                        select u).FirstOrDefault();
            }
        }

        public List<Role> GetRoles()
        {
            PropertyHubContext context = new PropertyHubContext();
            using (context)
            {
                return (from u in context.Roles
                        select u).ToList();
            }
        }

    }
}
