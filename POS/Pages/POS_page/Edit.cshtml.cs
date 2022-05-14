using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;

namespace POS.Pages.POS_page
{
    public class EditModel : PageModel
    {
        private readonly POS.Data.ApplicationDbContext _context;

        public EditModel(POS.Data.ApplicationDbContext context)
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
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PosTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosTaskExists(PosTask.Id))
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

        private bool PosTaskExists(long id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
