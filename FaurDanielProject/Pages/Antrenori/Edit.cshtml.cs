using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FaurDanielProiectMedii.Models;

namespace FaurDanielProject.Pages.Antrenori
{
    public class EditModel : PageModel
    {
        private readonly FaurDanielProjectContext _context;

        public EditModel(FaurDanielProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Antrenor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntrenorExists(Antrenor.ID))
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

        private bool AntrenorExists(int id)
        {
            return _context.Antrenor.Any(e => e.ID == id);
        }
    }
}
