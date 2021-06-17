using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Zad3.Models;
using Microsoft.Extensions.Configuration;
using Zad3.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Zad3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IConfiguration _configuration { get; }
        public List<Numbers> NumbersList { get; set; }

        [BindProperty]
        public Numbers Numbers { get; set; }

        [TempData]
        public string Message { get; set; }
        private readonly NumberContext _context;

        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger, NumberContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
        }
        public IList<Numbers> Number { get; set; }
        public void OnGet()
        {
            Number = _context.Numbers.ToList();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var SessionNumbersList = HttpContext.Session.GetString("SessionNumberList");
                if (SessionNumbersList != null)
                {
                    NumbersList = JsonConvert.DeserializeObject<List<Numbers>>(SessionNumbersList);
                }
                else NumbersList = new List<Numbers>();
                if (Numbers.Number % 3 == 0)
                {
                    Message += "Fizz";
                }
                if (Numbers.Number % 5 == 0)
                {
                    Message += "Buzz";
                }
                if (Message == null)
                {
                    Message += $"Liczba: { Numbers.Number} nie spełnia kryteriów Fizz / Buzz";
                }
                Numbers.Message = Message;
                Numbers.Date = DateTime.Now;
                NumbersList.Add(Numbers);
                _context.Numbers.Add(Numbers);
                _context.SaveChanges();

                HttpContext.Session.SetString("SessionNumberList", JsonConvert.SerializeObject(NumbersList));
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }

        }

    }
}
