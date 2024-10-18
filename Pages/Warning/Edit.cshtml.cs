using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trans_track.Data;
using trans_track.Models;

namespace trans_track.Pages.Warning
{
    public class EditModel : PageModel
    {
        private readonly trans_track.Data.ApplicationDbContext _context;

        public EditModel(trans_track.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public trans_track.Models.Warning Warning { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Warning = await _context.Warning.FirstOrDefaultAsync(m => m.ID == id);

            if (Warning == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Warning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarningExists(Warning.ID))
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

        private bool WarningExists(int id)
        {
            return _context.Warning.Any(e => e.ID == id);
        }
    }
}
