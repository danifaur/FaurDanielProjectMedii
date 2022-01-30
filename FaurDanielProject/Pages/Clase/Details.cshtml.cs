using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaurDanielProiectMedii.Models;

namespace FaurDanielProject.Pages.Clase
{
    public class DetailsModel : PageModel
    {
        private readonly FaurDanielProjectContext _context;

        public DetailsModel(FaurDanielProjectContext context)
        {
            _context = context;
        }

        public Clasa Clasa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clasa = await _context.Clasa
                .Include(c => c.Antrenor)
                .Include(c => c.Intensitate)
                .Include(c => c.Nivel).FirstOrDefaultAsync(m => m.ID == id);

            if (Clasa == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
