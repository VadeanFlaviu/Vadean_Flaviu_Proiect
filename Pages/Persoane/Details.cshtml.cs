using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vadean_Flaviu_Proiect.Data;
using Vadean_Flaviu_Proiect.Models;

namespace Vadean_Flaviu_Proiect.Pages.Persoane
{
    public class DetailsModel : PageModel
    {
        private readonly Vadean_Flaviu_Proiect.Data.Vadean_Flaviu_ProiectContext _context;

        public DetailsModel(Vadean_Flaviu_Proiect.Data.Vadean_Flaviu_ProiectContext context)
        {
            _context = context;
        }

        public Persoana Persoana { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Persoana = await _context.Persoana
                .Include(p => p.SectieVotare).FirstOrDefaultAsync(m => m.ID == id);

            if (Persoana == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
