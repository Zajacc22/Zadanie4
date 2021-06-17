using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zad3.Data;
using Zad3.Models;

namespace Zad3.Pages.Number
{
    public class CreateModel : PageModel
    {
        private readonly Zad3.Data.NumberContext _context;

        public CreateModel(Zad3.Data.NumberContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Numbers Numbers { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Numbers.Add(Numbers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
