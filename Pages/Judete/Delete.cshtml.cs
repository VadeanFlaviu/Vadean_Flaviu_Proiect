using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vadean_Flaviu_Proiect.Data;
using Vadean_Flaviu_Proiect.Models;

namespace Vadean_Flaviu_Proiect.Pages.Judete
{
    public class DeleteModel : PageModel
    {
        private readonly Vadean_Flaviu_Proiect.Data.Vadean_Flaviu_ProiectContext _context;

        public DeleteModel(Vadean_Flaviu_Proiect.Data.Vadean_Flaviu_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Judet Judete { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Judete = await _context.Judet.FirstOrDefaultAsync(m => m.ID == id);

            if (Judete == null)
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

            Judete = await _context.Judet.FindAsync(id);

            if (Judete != null)
            {
                _context.Judet.Remove(Judete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
