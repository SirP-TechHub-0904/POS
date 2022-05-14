using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POS.Data;

namespace POS.Pages.POS_page
{
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class AllModel : PageModel
    {
        private readonly POS.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AllModel(POS.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<PosTask> PosTask { get;set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            PosTask = await _context.Tasks
                .Include(p => p.User).Where(x => x.UserId == user.Id).OrderByDescending(x => x.Date).ToListAsync();
        }
    }
}
