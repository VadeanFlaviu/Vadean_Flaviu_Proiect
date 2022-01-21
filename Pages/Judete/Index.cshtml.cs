using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vadean_Flaviu_Proiect;
using Vadean_Flaviu_Proiect.Models;

namespace Vadean_Flaviu_Proiect.Pages.Judete
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

        public PaginatedList<Judet> Judete { get;set; }

        public string DenumireSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchName, int? pageIndex)
        {          
            CurrentSort = sortOrder;
            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "descrescator" : "";
            if (searchName != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchName = currentFilter;
            }
            CurrentFilter = searchName;

            IQueryable<Judet> judeteSortate = from s in _context.Judet
                                             select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                judeteSortate = judeteSortate.Where(s => s.Denumire.Contains(searchName));
            }

            switch (sortOrder)
            {
                case "descrescator":
                    judeteSortate = judeteSortate.OrderByDescending(s => s.Denumire);
                    break;
                default:
                    judeteSortate = judeteSortate.OrderBy(s => s.Denumire);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 10);
            Judete = await PaginatedList<Judet>.CreateAsync(
                judeteSortate.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
