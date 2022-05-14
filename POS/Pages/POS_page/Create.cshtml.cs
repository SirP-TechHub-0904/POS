using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Data;

namespace POS.Pages.POS_page
{
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class CreateModel : PageModel
    {
        private readonly POS.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(POS.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public PosTask PosTask { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            PosTask.Title = PosTask.Date.ToString("ddd dd MMM, yyyy");
            PosTask.UserId = user.Id;
            PosTask.MoniePointCharges = 0;
            //PosTask.A_Pay = 0;
            PosTask.CityCharges = 0;
            //PosTask.P_Pay = 0;
            PosTask.TotalCharges = 0;
            _context.Tasks.Add(PosTask);
            await _context.SaveChangesAsync();

            Expenditure e = new Expenditure();
            e.Date = DateTime.UtcNow.AddHours(1);
            e.TaskId = PosTask.Id;
            e.Description = "no expenses recorded";
            e.Amount = 0;
            _context.Expenditures.Add(e);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = PosTask.Id });
        }
    }
}
