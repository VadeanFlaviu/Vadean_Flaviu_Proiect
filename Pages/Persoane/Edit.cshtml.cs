using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vadean_Flaviu_Proiect.Data;
using Vadean_Flaviu_Proiect.Models;

namespace Vadean_Flaviu_Proiect.Pages.Persoane
{
    public class EditModel : PageModel
    {
        private readonly Vadean_Flaviu_Proiect.Data.Vadean_Flaviu_ProiectContext _context;

        public EditModel(Vadean_Flaviu_Proiect.Data.Vadean_Flaviu_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["SectieVotareID"] = new SelectList(_context.SectieVotare, "ID", "Adresa");
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

            _context.Attach(Persoana).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersoanaExists(Persoana.ID))
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

        private bool PersoanaExists(int id)
        {
            return _context.Persoana.Any(e => e.ID == id);
        }
    }
}
