using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POS.Data;

namespace POS.Pages.POS_page
{
    public class DeleteModel : PageModel
    {
        private readonly POS.Data.ApplicationDbContext _context;

        public DeleteModel(POS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PosTask PosTask { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PosTask = await _context.Tasks
                .Include(p => p.User).FirstOrDefaultAsync(m => m.Id == id);

            if (PosTask == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PosTask = await _context.Tasks.FindAsync(id);

            if (PosTask != null)
            {
                _context.Tasks.Remove(PosTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
