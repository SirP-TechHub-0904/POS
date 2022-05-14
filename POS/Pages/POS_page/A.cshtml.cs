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
    public class AModel : PageModel
    {
        private readonly POS.Data.ApplicationDbContext _context;

        public AModel(POS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Activity> Activity { get;set; }

        public async Task OnGetAsync()
        {
            Activity = await _context.Activities
                .Include(a => a.Task).ToListAsync();
        }
    }
}
