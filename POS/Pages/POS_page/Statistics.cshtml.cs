using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POS.Data;

namespace POS.Pages.POS_page
{
    [Authorize]
    public class StatisticsModel : PageModel
    {
        private readonly POS.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public StatisticsModel(POS.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<PosTask> PosTask { get;set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            PosTask = await _context.Tasks
                .Include(p => p.User)
                .Include(p => p.Activities)
                .Include(p => p.Expenditure)
                .Where(x=>x.Close == false).Where(x=>x.UserId == user.Id).OrderByDescending(x => x.Date).ToListAsync();
        }
    }
}
