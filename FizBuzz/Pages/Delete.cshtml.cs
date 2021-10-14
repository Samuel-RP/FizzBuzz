using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizBuzz.Data;
using FizBuzz.Models;

namespace FizBuzz.Pages.Numbers
{
    public class DeleteModel : PageModel
    {
        private readonly FizBuzz.Data.FizBuzzContext _context;

        public DeleteModel(FizBuzz.Data.FizBuzzContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NumTable = await _context.NumTable.FindAsync(id);

            if (NumTable != null)
            {
                _context.NumTable.Remove(NumTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
