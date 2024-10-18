using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using trans_track.Data;
using trans_track.Models;

namespace trans_track.Pages.Rule
{
    public class CreateModel : PageModel
    {
        private readonly trans_track.Data.ApplicationDbContext _context;

        public CreateModel(trans_track.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public trans_track.Models.Rule Rule { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rule.Add(Rule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}