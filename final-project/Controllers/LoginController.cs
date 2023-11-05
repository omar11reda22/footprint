using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using final_project.Models;
using final_project.myContext;
using final_project.viewmodel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Data.Common;
using static Azure.Core.HttpHeader;

namespace final_project.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult checklol(LoginView user)
        {
            ITIContext contextcontext = new ITIContext();
            var data = contextcontext.users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (data != null)
            {
                HttpContext.Session.SetInt32("UserId", data.user_Id);
                HttpContext.Session.SetString("Email", data.Email);
                HttpContext.Session.SetString("Password", data.Password);

                ViewData["Email"] = data.Email;
                return RedirectToAction("afterindex", "Home");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult register()
        {
            ITIContext context = new ITIContext();

            Registerviewmodel registerviewmodel = new Registerviewmodel();
            List<SelectListItem> countries = context.countries
                .OrderBy(n => n.name)
                .Select(n => new SelectListItem
                {
                    Value = n.Country_ID.ToString(),
                    Text = n.name
                }).ToList();

            registerviewmodel.countries = countries;
            registerviewmodel.cities = new List<SelectListItem>();
            registerviewmodel.governorates = new List<SelectListItem>();



            return View(registerviewmodel);

        }
        [HttpPost]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetCities(int GovernoratCode)
        {
            if (GovernoratCode > 0)
            {
                ITIContext context = new ITIContext();
                List<SelectListItem> cities1 = context.cities
                    .Where(c => c.G_ID == GovernoratCode)
                .OrderBy(n => n.name)
                .Select(n => new SelectListItem
                {
                    Value = n.City_ID.ToString(),
                    Text = n.name
                }).ToList();
                return Json(cities1);
            }
            return null;
        }

        [HttpGet]
        public IActionResult GetGovernorat(int CountryCode)
        {
            if (CountryCode > 0)
            {
                ITIContext context = new ITIContext();
                List<SelectListItem> governorates1 = context.governorates
                    .Where(c => c.Country_ID == CountryCode)
                .OrderBy(n => n.name)
                .Select(n => new SelectListItem
                {
                    Value = n.G_ID.ToString(),
                    Text = n.name
                }).ToList();
                return Json(governorates1);
            }
            return null;
        }

        [HttpPost]
        public IActionResult saveregister(Registerviewmodel registerviewmodel)
        {
            var selectedCountry = registerviewmodel.lstCountry;
            var selectedCity = registerviewmodel.lstCity;
            var selectedGovernorate = registerviewmodel.lstGovernorat;
            ITIContext context = new ITIContext();

            try
            {
                if (registerviewmodel.password != registerviewmodel.confirmpassword)
                    return RedirectToAction("register");
                var getUser = context.users.FirstOrDefault(a => a.Email == registerviewmodel.Email);

                if (getUser != null)
                {
                    return RedirectToAction("register");
                }
              
                User user = new User()
                {
                    Email = registerviewmodel.Email,
                    Password = registerviewmodel.password
                };

                context.users.Add(user);
                context.SaveChanges();

                getUser = context.users.FirstOrDefault(a => a.Email == user.Email);

                address address = new address()
                {
                    country_ID = selectedCountry,
                    city_ID = selectedCity,
                    governorate_ID = selectedGovernorate,
                    useruser_ID = getUser.user_Id
                };

                context.addresses.Add(address);
                context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch (Exception ex) { }
            return RedirectToAction("register");

        }
    }
}