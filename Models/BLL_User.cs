using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Security;
using Test.Data;

namespace Test.Models
{
    public class BLL_User
    {
        EMPTYDBEntities context = new EMPTYDBEntities();
        public int AddUser(SignupViewModel model)
        {
            var isExist = context.Users.Where(x => x.email == model.Email).Any();
            if (!isExist)
            {
                User obj = new User();
                obj.userId = model.UserId;
                obj.name = model.Name;
                obj.email = model.Email;
                obj.roleId = 1;
                obj.password = model.Password;
                context.Users.Add(obj);
                context.SaveChanges();
            }
            return isExist ? 0 : 1;
        }

        public List<SignupViewModel> GetUsers()
        {

            List<SignupViewModel> list = new List<SignupViewModel>();
            //  var users = context.Users.ToList();
            var query = (from p in context.Users
                         join r in context.roles on p.roleId equals r.ID
                         select new { p.userId, p.name, p.email, RoleName = r.name }).ToList();

            foreach (var user in query)
            {
                SignupViewModel obj = new SignupViewModel();

                obj.UserId = user.userId;
                obj.Name = user.name;
                obj.Email = user.email.ToLower();
                obj.RoleName = user.RoleName;

                list.Add(obj);
            }

            return list;
        }

        public int DeleteUser(int id)
        {
            var delUser = context.Users.FirstOrDefault(x => x.userId == id);
            if (delUser != null)
            {
                context.Users.Remove(delUser);
            }

            return context.SaveChanges();
        }

        public int UpdateUser(UserUpdateViewModel model)
        {
            var user = context.Users.FirstOrDefault(x => x.userId == model.HidId);
            if (user != null)
            {
                user.name = model.EName;
                user.email = model.EEmail;

                context.SaveChanges();

                return 1;
            }

            return 0;
        }


        public void AddUserDetails(AddDetailsModel model)
        {
            var user = context.Users.FirstOrDefault(x => x.userId == model.UserID);
            if (user != null)
            {
                var detailsExist = context.personalInfoes.Where(x => x.userID == model.UserID).Any();
                if (detailsExist) // If details already exist then there will be no change and return.
                {
                    return;
                }


                //var countryname = context.countries.Where(x => x.CID == model.CountryID).FirstOrDefault();
                //var statename = context.states.Where(x => x.SID == model.StateID).FirstOrDefault();

                var result = context.states
                            .Where(s => s.SID == model.StateID)
                            .Select(x => new { StateName = x.State1, CountryName = x.country.Country1 })
                            .FirstOrDefault();

                personalInfo obj = new personalInfo();

                obj.PID = model.PID;
                obj.Gender = model.Gender;

                obj.Country = result.CountryName;
                obj.State = result.StateName;

                obj.CountryID = model.CountryID;
                obj.StateID = model.StateID;
                obj.userID = model.UserID;

                context.personalInfoes.Add(obj);
                context.SaveChanges();
            }

            return;
        }


        public ViewDetailsModel ViewUserDetails(int id)
        {
            //var data = (from p in context.personalInfoes // This is using Linq.
            //            where p.userID == id
            //            join u in context.Users
            //            on p.userID equals u.userId
            //            select new { UserName = u.name, p.Gender, p.State, p.Country }).FirstOrDefault();


            var data = context.GetViewDetails(id).FirstOrDefault(); // This is using stored procedure.

            ViewDetailsModel obj = new ViewDetailsModel();
            if (data != null)
            {
                obj.Name = data.UserName;
                obj.Gender = data.Gender;
                obj.State = data.State;
                obj.Country = data.Country;
            }
            return obj;
        }


    }
}