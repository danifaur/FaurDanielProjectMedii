using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaurDanielProiectMedii.Models;

namespace FaurDanielProject.Pages.Antrenori
{
    public class DetailsModel : PageModel
    {
        private readonly FaurDanielProjectContext _context;

        public DetailsModel(FaurDanielProjectContext context)
        {
            _context = context;
        }

        public Antrenor Antrenor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Antrenor = await _context.Antrenor.FirstOrDefaultAsync(m => m.ID == id);

            if (Antrenor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
