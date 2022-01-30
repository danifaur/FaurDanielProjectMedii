using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FaurDanielProiectMedii.Models;

namespace FaurDanielProject.Pages.Intensitati
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
        public Intensitate Intensitate { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Intensitate.Add(Intensitate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
