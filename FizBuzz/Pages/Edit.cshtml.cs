using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FizBuzz.Data;
using FizBuzz.Models;

namespace FizBuzz.Pages.Numbers
{
    public class EditModel : PageModel
    {
        private readonly FizBuzz.Data.FizBuzzContext _context;

        public EditModel(FizBuzz.Data.FizBuzzContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NumTable NumTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NumTable = await _context.NumTable.FirstOrDefaultAsync(m => m.ID == id);

            if (NumTable == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NumTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumTableExists(NumTable.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NumTableExists(int id)
        {
            return _context.NumTable.Any(e => e.ID == id);
        }
    }
}
