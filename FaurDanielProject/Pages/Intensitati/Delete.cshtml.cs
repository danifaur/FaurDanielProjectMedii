using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaurDanielProiectMedii.Models;

namespace FaurDanielProject.Pages.Intensitati
{
    public class DeleteModel : PageModel
    {
        private readonly FaurDanielProjectContext _context;

        public DeleteModel(FaurDanielProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Intensitate Intensitate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Intensitate = await _context.Intensitate.FirstOrDefaultAsync(m => m.ID == id);

            if (Intensitate == null)
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

            Intensitate = await _context.Intensitate.FindAsync(id);

            if (Intensitate != null)
            {
                _context.Intensitate.Remove(Intensitate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
