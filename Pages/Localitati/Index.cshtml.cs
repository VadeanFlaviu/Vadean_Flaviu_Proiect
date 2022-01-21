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

namespace Vadean_Flaviu_Proiect.Pages.Localitati
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

        public PaginatedList<Localitate> Localitati { get;set; }

        public string DenumireSort { get; set; }
        public string JudetSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchName, int? pageIndex)
        {
            CurrentSort = sortOrder;
            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "localitate_descrescator" : "";
            JudetSort = sortOrder == "judet" ? "judet_descrescator" : "judet";
            if (searchName != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchName = currentFilter;
            }
            CurrentFilter = searchName;

            IQueryable<Localitate> localitatiSortate = from s in _context.Localitate
                                              select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                localitatiSortate = localitatiSortate.Where(s => s.Denumire.Contains(searchName));
            }

            switch (sortOrder)
            {
                case "localitate_descrescator":
                    localitatiSortate = localitatiSortate.OrderByDescending(s => s.Denumire);
                    break;
                case "judet_descrescator":
                    localitatiSortate = localitatiSortate.OrderByDescending(s => s.Judet.Denumire);
                    break;
                case "judet":
                    localitatiSortate = localitatiSortate.OrderBy(s => s.Judet.Denumire);
                    break;
                default:
                    localitatiSortate = localitatiSortate.OrderBy(s => s.Denumire);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 10);
            Localitati = await PaginatedList<Localitate>.CreateAsync(
                localitatiSortate.AsNoTracking().Include(s => s.Judet), pageIndex ?? 1, pageSize);

        }
    }
}
