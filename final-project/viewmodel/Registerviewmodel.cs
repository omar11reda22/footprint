using final_project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace final_project.viewmodel
{
    public class Registerviewmodel
    {
        public int lstCountry { get; set; }
        public int lstCity { get; set; }
        public int lstGovernorat { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public List<SelectListItem> countries { get; set; }
        public List<SelectListItem> cities { get; set; }
        public List<SelectListItem> governorates { get; set; }

    }
}