using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vadean_Flaviu_Proiect.Data;
using Vadean_Flaviu_Proiect.Models;

namespace Vadean_Flaviu_Proiect.Pages.SectiiVotare
{
    public class IndexModel : PageModel
    {
        private readonly Vadean_Flaviu_Proiect.Data.Vadean_Flaviu_ProiectContext _context;
        private readonly IConfiguration Configuration;
        public IndexModel(Vadean_Flaviu_Proiect.Data.Vadean_Flaviu_ProiectContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string DenumireSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<SectieVotare> SectieVotare { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchName, int? pageIndex)
        {
            CurrentSort = sortOrder;
            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "localitate_descrescator" : "";
            if (searchName != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchName = currentFilter;
            }
            CurrentFilter = searchName;

            IQueryable<SectieVotare> sectiiVotareSortate = from s in _context.SectieVotare
                                                       select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                sectiiVotareSortate = sectiiVotareSortate.Where(s => s.Adresa.Contains(searchName));
            }

            switch (sortOrder)
            {
                case "localitate_descrescator":
                    sectiiVotareSortate = sectiiVotareSortate.OrderByDescending(s => s.Localitate.Denumire);
                    break;
                default:
                    sectiiVotareSortate = sectiiVotareSortate.OrderBy(s => s.Localitate.Denumire);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 10);
            SectieVotare = await PaginatedList<SectieVotare>.CreateAsync(
                sectiiVotareSortate.AsNoTracking().Include(s => s.Localitate), pageIndex ?? 1, pageSize);
        }
    }
}
