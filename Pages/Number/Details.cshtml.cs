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
    public class DetailsModel : PageModel
    {
        private readonly Zad3.Data.NumberContext _context;

        public DetailsModel(Zad3.Data.NumberContext context)
        {
            _context = context;
        }

        public Numbers Numbers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Numbers = await _context.Numbers.FirstOrDefaultAsync(m => m.Id == id);

            if (Numbers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
