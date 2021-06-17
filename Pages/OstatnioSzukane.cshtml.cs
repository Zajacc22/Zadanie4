using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zad3.Data;
using Zad3.Models;

namespace Zad3.Pages
{
    public class OstatnioSzukaneModel : PageModel
    {
        private readonly NumberContext _context;
        public IList<Numbers> Number { get; set; }
        public OstatnioSzukaneModel(NumberContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            var NumbersQuery = (from Number in
                    _context.Numbers
                                orderby Number.Date descending
                                select Number).Take(10);
            Number = NumbersQuery.ToList();
        }
    }
}
