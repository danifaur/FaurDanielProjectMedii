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
    public class IndexModel : PageModel
    {
        private readonly FaurDanielProjectContext _context;

        public IndexModel(FaurDanielProjectContext context)
        {
            _context = context;
        }

        public IList<Intensitate> Intensitate { get;set; }

        public async Task OnGetAsync()
        {
            Intensitate = await _context.Intensitate.ToListAsync();
        }
    }
}
