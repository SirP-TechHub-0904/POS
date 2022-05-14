using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POS.Data;

namespace POS.Areas.Admin.Page.EXPENSES
{
    public class DetailsModel : PageModel
    {
        private readonly POS.Data.ApplicationDbContext _context;

        public DetailsModel(POS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Expenditure Expenditure { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expenditure = await _context.Expenditures
                .Include(e => e.Task).FirstOrDefaultAsync(m => m.Id == id);

            if (Expenditure == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
