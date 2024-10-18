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
    public class IndexModel : PageModel
    {
        private readonly trans_track.Data.ApplicationDbContext _context;

        public IndexModel(trans_track.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<trans_track.Models.ServiceType> ServiceType { get;set; }

        public async Task OnGetAsync()
        {
            ServiceType = await _context.ServiceType.ToListAsync();
        }
    }
}
