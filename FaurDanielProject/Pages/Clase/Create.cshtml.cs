using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FaurDanielProiectMedii.Models;

namespace FaurDanielProject.Pages.Clase
{
    public class CreateModel : PageModel
    {
        private readonly FaurDanielProjectContext _context;

        public CreateModel(FaurDanielProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AntrenorID"] = new SelectList(_context.Set<Antrenor>(), "ID", "nume");
        ViewData["IntensitateID"] = new SelectList(_context.Set<Intensitate>(), "ID", "Nume");
        ViewData["NivelID"] = new SelectList(_context.Set<Nivel>(), "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Clasa Clasa { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clasa.Add(Clasa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
