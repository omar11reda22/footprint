using final_project.Models;
using final_project.myContext;
using final_project.viewmodel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace final_project.Controllers
{
    public class HomeController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult afterindex()
        {
            return View();
        }
        public IActionResult Home()
        {

            return View();
        }
        public IActionResult savingdata(double value)
        {
            if (value < 0) { return RedirectToAction("Fail"); }
            question questionquestion = new question();
            var data = context.questions.Where(c => c.Question_ID == 1).Select(c => c.factor);

            var valueResult = value * data.First();
            result result = new result()
            {
                Question_ID = 1,
                user_Id = (int)HttpContext.Session.GetInt32("UserId"),
                value = valueResult
            };
            context.results.Add(result);
            context.SaveChanges();



            return RedirectToAction("Waste");
        }

        public IActionResult Waste()
        {

            return View();
        }
        public IActionResult savewaste(double value)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32("UserId").ToString()))
            {
                return RedirectToAction("Index");
            }
            if (value < 0) { return RedirectToAction("Fail"); }
            question question = new question();
            var data = context.questions.Where(c => c.Question_ID == 19).Select(c => c.factor);
            result result = new result();
            result.Question_ID = 19;
            result.user_Id = (int)HttpContext.Session.GetInt32("UserId");

            if (value == 1)
            {
                result.value = 1 * data.First();
            }
            else if (value == 2)
            {
                result.value = 2 * data.First();
            }
            else if (value == 3)
            {
                result.value = 3 * data.First();
            }
            else if (value == 4)
            {
                result.value = 4 * data.First();
            }
            else if (value == 5)
            {
                result.value = 5 * data.First();
            }
            context.results.Add(result);
            context.SaveChanges();

            return RedirectToAction("Food");
        }
        public IActionResult Food()
        {


            return View();
        }
        public IActionResult saveFood(SaveFoodModel saveFoodModel)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32("UserId").ToString()))
            {
                return RedirectToAction("Index");
            }
            result result = new result();
            var data = context.questions;
            for (int i = 2; i <= 13; i++)
            {
                result = new result();
                result.Question_ID = i;
                result.user_Id = (int)HttpContext.Session.GetInt32("UserId");
                if (i == 2)
                    result.value = saveFoodModel.beef * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 3)
                    result.value = saveFoodModel.chiken * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 4)
                    result.value = saveFoodModel.turkey * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 5)
                    result.value = saveFoodModel.cheese * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 6)
                    result.value = saveFoodModel.eggs * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 7)
                    result.value = saveFoodModel.tuna * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 8)
                    result.value = saveFoodModel.potatoes * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 9)
                    result.value = saveFoodModel.rice * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 10)
                    result.value = saveFoodModel.beens * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 11)
                    result.value = saveFoodModel.vegetabols * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 12)
                    result.value = saveFoodModel.milk * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 13)
                    result.value = saveFoodModel.fruit * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();

                context.results.Add(result);
                context.SaveChanges();
            }

            return RedirectToAction("transportation");
        }
        public IActionResult transportation()
        {
            return View();
        }

        public IActionResult savetransportation(SaveFoodModel saveFoodModel)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32("UserId").ToString()))
            {
                return RedirectToAction("Index");
            }
            result result = new result();
            var data = context.questions;

            for (int i = 14; i <= 18; i++)
            {
                result = new result();
                result.Question_ID = i;
                result.user_Id = (int)HttpContext.Session.GetInt32("UserId");
                if (i == 14)
                    result.value = saveFoodModel.car * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 15)
                    result.value = saveFoodModel.car * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 16)
                    result.value = saveFoodModel.car * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 17)
                    result.value = saveFoodModel.car * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();
                else if (i == 18)
                    result.value = saveFoodModel.car * data.Where(c => c.Question_ID == i).Select(c => c.factor).First();

                context.results.Add(result);
                context.SaveChanges();
            }

            return RedirectToAction("Detailresult");
        }

        public IActionResult Detailresult()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32("UserId").ToString()))
            {
                return RedirectToAction("Index");
            }

            int id = (int)HttpContext.Session.GetInt32("UserId");
            var result = context.results.Where(d => d.user_Id == id).ToList();

            if (result == null || result.Count == 0)
                return RedirectToAction("Index");

            var Homes = result.Find(d => d.Question_ID == 1).value;
            var Foods = 0.0;
            for (int i = 2; i <= 13; i++)
            {

                Foods += result.Find(d => d.Question_ID == i).value;
            }
            var Transportations = 0.0;

            for (int i = 14; i <= 18; i++)
            {

                Transportations += result.Find(d => d.Question_ID == i).value;
            }

            var data3 = result.Find(d => d.Question_ID == 19).value;
            var Totalresults = 0.0;
            for (int i = 1; i <= 19; i++)
            {
                Totalresults += result.Find(d => d.Question_ID == i).value;

            }
            ViewData["Waste"] = data3.ToString();
            ViewData["Food"] = Foods.ToString();
            ViewData["Home"] = Homes.ToString();
            ViewData["Transportation"] = Transportations.ToString();
            ViewData["Totalresult"] = Totalresults.ToString();
            return View();
        }
        public IActionResult governorate_Details()
        {

            var all_governorate = context.governorates.ToList();
            var result = context.results.ToList();
            var total_value = 0.0;

            Dictionary<string, double> governorate_co2s = new Dictionary<string, double>();

            foreach (var gov in all_governorate)
            {
                var u_id = context.addresses.Where(x => x.governorate_ID == gov.G_ID).Select(a => a.useruser_ID).ToList();
                if (u_id == null || u_id.Count == 0)
                    continue;
                var r = result.Where(x => u_id.Contains(x.user_Id)).Select(a => a.value).ToList();
                if (r == null || r.Count == 0)
                    continue;
                total_value = r.Sum();
                governorate_co2s.Add(gov.name, total_value);
            }
            ViewData["Governorate_co2s"] = governorate_co2s;





            return View();
        }
    }
}
