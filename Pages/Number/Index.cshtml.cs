using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zad3.Data;
using Zad3.Models;

namespace Zad3.Pages.Number
{
    public class IndexModel : PageModel
    {
        private readonly Zad3.Data.NumberContext _context;

        public IndexModel(Zad3.Data.NumberContext context)
        {
            _context = context;
        }

        public IList<Numbers> Numbers { get;set; }

        public async Task OnGetAsync()
        {
            Numbers = await _context.Numbers.ToListAsync();
        }
    }
}
