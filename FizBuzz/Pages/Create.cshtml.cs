using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FizBuzz.Data;
using FizBuzz.Models;

namespace FizBuzz.Pages.Numbers
{
    public class CreateModel : PageModel
    {
        private readonly FizBuzz.Data.FizBuzzContext _context;

        public CreateModel(FizBuzz.Data.FizBuzzContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NumTable NumTable { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NumTable.Add(NumTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
