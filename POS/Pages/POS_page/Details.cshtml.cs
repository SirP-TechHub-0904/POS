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
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class DetailsModel : PageModel
    {
        private readonly POS.Data.ApplicationDbContext _context;

        public DetailsModel(POS.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public decimal MachineAfter { get; set; }

        [BindProperty]
        public decimal CashAfter { get; set; }

        [BindProperty]
        public long TID { get; set; }
        [BindProperty]
        public PosTask PosTask { get; set; }
        public IList<Activity> ActivityList { get; set; }

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

            Expenditure = await _context.Expenditures
               .Include(e => e.Task).FirstOrDefaultAsync(m => m.TaskId == id);
            ActivityList = await _context.Activities
                .Include(a => a.Task).OrderByDescending(c => c.Date).Where(m => m.TaskId == id).ToListAsync();

            //
            var t = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            var transaction = await _context.Activities.Where(x => x.TaskId == id).ToListAsync();
            var xExpenditure = await _context.Expenditures
                .Include(e => e.Task).FirstOrDefaultAsync(m => m.TaskId == id);

            var xTotalCharges = transaction.Sum(x => x.CityCharge);
            var xMoniePointCharges = transaction.Sum(x => x.moniepointCharge);
            t.TotalCharges = xTotalCharges;
            t.MoniePointCharges = xMoniePointCharges;
            var xCityCharges = xTotalCharges - xMoniePointCharges;
            t.CityCharges = xCityCharges;

            ///
            //p
            double fp = 40 / 100d;
            double xp = 20 / 100d;
            decimal ppercent = Convert.ToDecimal(fp) * Convert.ToDecimal(xCityCharges);
            decimal opercent = Convert.ToDecimal(fp) * Convert.ToDecimal(xCityCharges);
            decimal citypercent = Convert.ToDecimal(xp) * Convert.ToDecimal(xCityCharges);

            t.Admin_Pay = ppercent;
            t.Rep_Pay = opercent;
            t.Machine_Pay = citypercent;
            _context.Attach(t).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Page();
        }

        [BindProperty]
        public Activity Activity { get; set; }
        public Expenditure Expenditure { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Activities.Add(Activity);
            await _context.SaveChangesAsync();
            //
          





            return RedirectToPage("./Details", new { id = Activity.TaskId });
        }

        public async Task<IActionResult> OnPostUpdateTask()
        {
           var PosTask = await _context.Tasks
                .Include(p => p.User).FirstOrDefaultAsync(m => m.Id == TID);

            PosTask.AmountInCashAfter = CashAfter;
            PosTask.AmountInMachineAfter = MachineAfter;
            _context.Attach(PosTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = PosTask.Id });
        }
    }
}
