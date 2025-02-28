﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Data;

namespace POS.Areas.Admin.Page.EXPENSES
{
    public class CreateModel : PageModel
    {
        private readonly POS.Data.ApplicationDbContext _context;

        public CreateModel(POS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Expenditure Expenditure { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Expenditures.Add(Expenditure);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
