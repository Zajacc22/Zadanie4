using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zad3.Data;
using Zad3.Models;

namespace Zad3.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Zad3.Data.NumberContext _context;

        public DeleteModel(Zad3.Data.NumberContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Numbers = await _context.Numbers.FindAsync(id);

            if (Numbers != null)
            {
                _context.Numbers.Remove(Numbers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
