using EVS370.UsersMgt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EVS370.PropertyHub.WebUI.Models
{
    public static class ModelHelper
    {
        // signup
        public static User ToEntity(this SignupModel model)
        {
            User entity = new User();
            entity.Name = model.fullName;
            entity.LoginId = model.contactNum;
            entity.ContactNumber = model.contactNum;
            entity.BirthDate = model.BirthDate;
            entity.Password = model.password;
            entity.Role = new Role { Id=3};
            return entity;
        }
        public static SignupModel ToEntity(this User entity)
        {
            SignupModel modal = new SignupModel();
            modal.fullName = entity.Name;
            modal.contactNum = entity.ContactNumber;
            modal.BirthDate = entity.BirthDate;
            modal.password = entity.Password;
            return modal;
        }
        public static List<SelectListItem> ToItems(this IEnumerable<IListable> entities)
        {
            List<SelectListItem> items = new List<SelectListItem>();            
            foreach (var e in entities) 
            {
                items.Add(new SelectListItem { Text = e.Name, Value = Convert.ToString(e.Id) });
            }
            return items;
        }
        internal static List<SelectListItem> ToSelectListItems(this IEnumerable<IListable> entitiesList)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var entity in entitiesList)
            {
                items.Add(new SelectListItem { Text = entity.Name, Value = Convert.ToString(entity.Id) });
            }
            items.TrimExcess();
            return items;
        }

        public static PropertyAdv ToEntity(this PropertyAdvModel model)
        {
            PropertyAdv entity = new PropertyAdv();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.PostedOn = model.PostedOn;
            entity.ActiveTill = model.ActiveTill;
            entity.Neighborhood = model.Neighborhood.ToEntity();
            entity.PostedBy = model.PostedBy.ToEntity();
            entity.Status = model.Status.ToEntity();
            entity.Type = model.AdvType.ToEntity();
            entity.Area = model.Area.ToEntity();
            return entity;
        }

        public static PropertyAdvModel ToModel(this PropertyAdv entity)
        {
            PropertyAdvModel model = new PropertyAdvModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Price = entity.Price;
            model.Description = entity.Description;
            model.PostedOn = entity.PostedOn;
            model.ActiveTill = entity.ActiveTill;
            model.Neighborhood = entity.Neighborhood.ToModel();
            model.PostedBy = entity.PostedBy.ToModel();
            model.Area = entity.Area.ToModel();
            //model.Status = entity.Status.ToModel()
            //model.Type = entity.AdvType.ToEntity();

            if (entity.Images!=null)
            {
                foreach (var img in entity.Images)
                {
                    model.Images.Add(Convert.ToBase64String(img.Content));                    
                }
            }
            return model;
        }

        public static List<PropertyAdvModel> ToModelList(this List<PropertyAdv> entitiesList)
        {
            List<PropertyAdvModel> modelsList = new List<PropertyAdvModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }



        public static AdvStatus ToEntity(this AdvStatusModel model)
        {
            return new AdvStatus { Id = model.Id, Name=model.Name  };            
        }

        public static AdvType ToEntity(this AdvTypeModel model)
        {
            return new AdvType { Id = model.Id, Name = model.Name };
        }

        public static PropertyAreaUnit ToEntity(this PropertyAreaUnitModel model)
        {
            return new PropertyAreaUnit { Id = model.Id, Name = model.Name };
        }

        public static PropertyAreaUnitModel ToModel(this PropertyAreaUnit entity)
        {
            return new PropertyAreaUnitModel { Id = entity.Id, Name = entity.Name };
        }

        public static PropertyArea ToEntity(this PropertyAreaModel model)
        {
            return new PropertyArea { Id=model.Id, Value=model.value, PropertyAreaUnit=model.Unit?.ToEntity()  };
        }

        public static PropertyAreaModel ToModel(this PropertyArea entity)
        {
            return new PropertyAreaModel { Id = entity.Id, value = entity.Value, Unit = entity.PropertyAreaUnit.ToModel() };
        }

        public static User ToEntity(this UserModel model)
        {
            User entity = new User
            {
                Id = model.Id,
                Name = model.Name,
                Password = model.Password,
                BirthDate = model.BirthDate,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                IsActive = model.IsActive,
                LoginId = model.LoginId,
                SecurityQuestion = model.SecurityQuestion,
                SecurityAnswer = model.SecurityAnswer,
                ApiKey = model.ApiKey,
                Role = model.Role?.ToEntity()
            };
            return entity;
        }

        public static UserModel ToModel(this User entity)
        {
            UserModel model = new UserModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Password = entity.Password;
            model.BirthDate = entity.BirthDate;
            model.ContactNumber = entity.ContactNumber;
            model.Email = entity.Email;
            model.IsActive = entity.IsActive;
            model.LoginId = entity.LoginId;
            model.SecurityQuestion = entity.SecurityQuestion;
            model.SecurityAnswer = entity.SecurityAnswer;
            model.ApiKey = entity.ApiKey;
            if (entity.Image != null)
            {
                model.Image = Convert.ToBase64String(entity.Image);
            }            
            model.Role = entity.Role?.ToModel();
            model.Address = entity.Address?.ToModel();
            return model;
        }

        public static AddressModel ToModel(this Address entity)
        {
            AddressModel model = new AddressModel
            {
                Id = entity.Id,
                StreetAddress = entity.StreetAddress,
                City = entity.City?.ToModel()
            };
            return model;
        }


    public static RoleModel ToModel(this Role entity)
        {
            RoleModel model = new RoleModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return model;
        }

        public static Role ToEntity(this RoleModel model)
        {
            Role entity = new Role
            {
                Id = model.Id,
                Name = model.Name
            };
            return entity;
        }


        //country
        public static Country ToEntity(this CountryModel model)
        {
            return new Country { Id = model.Id, Code = model.Code, Name = model.Name };
        }
        public static CountryModel ToModel(this Country entity)
        {
            return new CountryModel { Id = entity.Id, Code = entity.Code, Name = entity.Name };
        }

        public static List<CountryModel> ToModelList(this List<Country> entitiesList)
        {
            List<CountryModel> modelsList = new List<CountryModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            return modelsList;
        }


        //province
        public static Province ToEntity(this ProvinceModel model)
        {
            return new Province { Id = model.Id, Name = model.Name, Country = model.Country?.ToEntity() };
        }

        public static ProvinceModel ToModel(this Province entity)
        {
            return new ProvinceModel { Id = entity.Id, Name = entity.Name, Country = entity.Country?.ToModel() };
        }



        public static List<ProvinceModel> ToModelList(this List<Province> entitiesList)
        {
            List<ProvinceModel> modelsList = new List<ProvinceModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }

        //city

        public static City ToEntity(this CityModel model)
        {
            return new City { Id = model.Id, Name = model.Name, Province = model.Province?.ToEntity() };
        }

        public static CityModel ToModel(this City entity)
        {
            return new CityModel { Id = entity.Id, Name = entity.Name, Province = entity.Province?.ToModel() };
        }

        public static List<CityModel> ToModelList(this List<City> entitiesList)
        {
            List<CityModel> modelsList = new List<CityModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }

        public static Neighborhood ToEntity(this NeighborhoodModel model)
        {
            Neighborhood entity = new Neighborhood();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.City = model.City?.ToEntity();
            return entity;
        }

        public static NeighborhoodModel ToModel(this Neighborhood entity)
        {
            NeighborhoodModel model = new NeighborhoodModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            if (entity.Image != null)
            {
                model.Image = Convert.ToBase64String(entity.Image);
            }
            model.City = entity.City?.ToModel();
            return model;
        }

        public static List<NeighborhoodModel> ToModelList(this List<Neighborhood> entitiesList)
        {
            List<NeighborhoodModel> modelsList = new List<NeighborhoodModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            return modelsList;
        }

    }
}
