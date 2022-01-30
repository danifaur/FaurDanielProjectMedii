using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaurDanielProiectMedii.Models;

namespace FaurDanielProject.Pages.Niveluri
{
    public class DeleteModel : PageModel
    {
        private readonly FaurDanielProjectContext _context;

        public DeleteModel(FaurDanielProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nivel Nivel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nivel = await _context.Nivel.FirstOrDefaultAsync(m => m.ID == id);

            if (Nivel == null)
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

            Nivel = await _context.Nivel.FindAsync(id);

            if (Nivel != null)
            {
                _context.Nivel.Remove(Nivel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
