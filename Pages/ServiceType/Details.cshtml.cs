using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using trans_track.Data;
using trans_track.Models;

namespace trans_track.Pages.ServiceType
{
    public class DetailsModel : PageModel
    {
        private readonly trans_track.Data.ApplicationDbContext _context;

        public DetailsModel(trans_track.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public trans_track.Models.ServiceType ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceType = await _context.ServiceType.FirstOrDefaultAsync(m => m.ID == id);

            if (ServiceType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
