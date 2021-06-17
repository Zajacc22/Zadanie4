using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Zad3.Models;

namespace Zad3.Pages
{
    public class LastFoundModel : PageModel
    {
        public List<Numbers> NumbersList;
        public void OnGet()
        {
            var SessionNumberListJSON = HttpContext.Session.GetString("SessionNumberList");
            if (SessionNumberListJSON != null)
            {
                NumbersList = JsonConvert.DeserializeObject<List<Numbers>>(SessionNumberListJSON);
            }
        }
    }
}
