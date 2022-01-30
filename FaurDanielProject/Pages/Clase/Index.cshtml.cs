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
    public class IndexModel : PageModel
    {
        private readonly FaurDanielProjectContext _context;

        public IndexModel(FaurDanielProjectContext context)
        {
            _context = context;
        }

        public IList<Clasa> Clasa { get;set; }

        public async Task OnGetAsync()
        {
            Clasa = await _context.Clasa
                .Include(c => c.Antrenor)
                .Include(c => c.Intensitate)
                .Include(c => c.Nivel).ToListAsync();
        }
    }
}
