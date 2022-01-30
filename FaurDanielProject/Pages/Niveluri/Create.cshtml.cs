using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FaurDanielProiectMedii.Models;

namespace FaurDanielProject.Pages.Niveluri
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
            return Page();
        }

        [BindProperty]
        public Nivel Nivel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Nivel.Add(Nivel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
