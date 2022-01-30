using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FaurDanielProiectMedii.Models;

namespace FaurDanielProject.Pages.Clase
{
    public class EditModel : PageModel
    {
        private readonly FaurDanielProjectContext _context;

        public EditModel(FaurDanielProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["AntrenorID"] = new SelectList(_context.Set<Antrenor>(), "ID", "nume");
           ViewData["IntensitateID"] = new SelectList(_context.Set<Intensitate>(), "ID", "Nume");
           ViewData["NivelID"] = new SelectList(_context.Set<Nivel>(), "ID", "Nume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Clasa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasaExists(Clasa.ID))
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

        private bool ClasaExists(int id)
        {
            return _context.Clasa.Any(e => e.ID == id);
        }
    }
}
