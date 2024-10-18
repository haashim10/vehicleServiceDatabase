using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using trans_track.Data;
using trans_track.Models;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Amazon.S3;
using Amazon;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Configuration;

namespace trans_track.Pages.Vehicle
{
    public class CreateModel : PageModel
    {
        private readonly trans_track.Data.ApplicationDbContext _context;
        private readonly ICommon _common;
        
        public CreateModel(trans_track.Data.ApplicationDbContext context, ICommon common)
        {
            _context = context;
            _common = common;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public trans_track.Models.Vehicle Vehicle { get; set; }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if (file != null && file.Length > 0)
                _common.UploadImage(Vehicle, file);
            
            _context.Vehicle.Add(Vehicle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}