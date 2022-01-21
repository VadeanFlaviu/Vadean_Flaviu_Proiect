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

namespace Vadean_Flaviu_Proiect.Pages.Persoane
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

        public PaginatedList<Persoana> Persoane { get;set; }

        public string DenumireSort { get; set; }
        public string NumeSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchName, int? pageIndex)
        {
            CurrentSort = sortOrder;
            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "localitate_descrescator" : "";
            NumeSort = sortOrder == "nume" ? "nume_descrescator" : "nume";
            if (searchName != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchName = currentFilter;
            }
            CurrentFilter = searchName;

            IQueryable<Persoana> persoaneSortate = from s in _context.Persoana
                                                       select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                persoaneSortate = persoaneSortate.Where(s => s.CNP.Contains(searchName) || s.NumePersoana.Contains(searchName));
            }

            switch (sortOrder)
            {
                case "localitate_descrescator":
                    persoaneSortate = persoaneSortate.OrderByDescending(s => s.SectieVotare.Localitate);
                    break;
                case "nume_descrescator":
                    persoaneSortate = persoaneSortate.OrderByDescending(s => s.NumePersoana);
                    break;
                case "nume":
                    persoaneSortate = persoaneSortate.OrderBy(s => s.NumePersoana);
                    break;
                default:
                    persoaneSortate = persoaneSortate.OrderBy(s => s.SectieVotare.Localitate);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 10);
            Persoane = await PaginatedList<Persoana>.CreateAsync(
                persoaneSortate.AsNoTracking().Include(s => s.SectieVotare).Include(s => s.SectieVotare.Localitate), pageIndex ?? 1, pageSize);
        }
    }
}
