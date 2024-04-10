using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    [Authorize]  //api/Home/RazorData
    public class HomeController : Controller
    {
        BLL_User bll = new BLL_User();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // Important Topics
        //[HttpGet("RazorData")]       // diff Ienumerable and Iqueriyable
        //// diff IEnumerable and List
        //public IActionResult<IEnumerable<SignupViewModel>> RazorData()
        //{
        //    var allUsers = bll.GetUsers();
        //   // ViewBag.AllUsers = allUsers;
        //    return Ok(allUsers);
        //}

        public ActionResult RazorData()
        {
            var allUsers = bll.GetUsers();
            ViewBag.AllUsers = allUsers;
            return View();
        }

        public ActionResult NormalData()
        {
            return View();
        }


        public JsonResult GetNormalUserData()
        {
            var allUsers = bll.GetUsers();
            return Json(allUsers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RazorDelete(int id)
        {
            bll.DeleteUser(id);

            return RedirectToAction("RazorData");
        }

        public ActionResult NormalDelete(int id)
        {
            bll.DeleteUser(id);

            return RedirectToAction("NormalData");
        }

        public ActionResult UserUpdate(UserUpdateViewModel model)
        {
            bll.UpdateUser(model);
            return RedirectToAction("RazorData");
        }

        public ActionResult CountriesData()
        {
            EMPTYDBEntities context = new EMPTYDBEntities();
            List<CountryModel> list = new List<CountryModel>();

            var data = context.countries.ToList();

            foreach (var country in data)
            {
                CountryModel obj = new CountryModel();

                obj.CID = country.CID;
                obj.Country1 = country.Country1;

                list.Add(obj);
            }
            
            var ansList = list;

            return Json(ansList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult StatesData(int id)
        {
            EMPTYDBEntities context = new EMPTYDBEntities();
            List<StateModel> list = new List<StateModel>();

            var data = context.states.Where(x => x.CountryId == id).ToList();

            foreach (var state in data)
            {
                StateModel obj = new StateModel();

                obj.SID = state.SID;
                obj.State = state.State1;

                list.Add(obj);
            }

            var states = list;

            return Json(states, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddDetails(AddDetailsModel model)
        {
            bll.AddUserDetails(model);


            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewDetails(int id)
        {
            var details = bll.ViewUserDetails(id);

            if (details != null)
            {
                return Json(details, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { error = "User details not found" }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}