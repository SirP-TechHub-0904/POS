using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;

namespace POS.Areas.Admin.Page.EXPENSES
{
    public class EditModel : PageModel
    {
        private readonly POS.Data.ApplicationDbContext _context;

        public EditModel(POS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id");
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

            _context.Attach(Expenditure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenditureExists(Expenditure.Id))
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

        private bool ExpenditureExists(long id)
        {
            return _context.Expenditures.Any(e => e.Id == id);
        }
    }
}
