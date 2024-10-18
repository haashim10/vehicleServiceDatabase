using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using trans_track.Data;
using trans_track.Models;

namespace trans_track.Pages.Warning
{
    public class DeleteModel : PageModel
    {
        private readonly trans_track.Data.ApplicationDbContext _context;

        public DeleteModel(trans_track.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Warning = await _context.Warning.FindAsync(id);

            if (Warning != null)
            {
                _context.Warning.Remove(Warning);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
