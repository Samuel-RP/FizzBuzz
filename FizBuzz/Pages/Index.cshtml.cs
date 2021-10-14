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
    public class IndexModel : PageModel
    {
        private readonly FizBuzz.Data.FizBuzzContext _context;

        public IndexModel(FizBuzz.Data.FizBuzzContext context)
        {
            _context = context;
        }

        public IList<NumTable> NumTable { get;set; }

        public async Task OnGetAsync()
        {
            NumTable = await _context.NumTable.ToListAsync();
        }
    }
}
