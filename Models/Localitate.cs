using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vadean_Flaviu_Proiect.Models
{
    public class Localitate
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][A-Za-z\s\-]+$", ErrorMessage = "Numele localitatii trebuie sa inceapa cu litera mare, poate contine 'spatiu' sau caracterul '-'"), Required, StringLength(100, MinimumLength = 3)]
        [Display(Name = "Localitate")]
        public string Denumire { get; set; }
        [Display(Name = "Judet")]
        public int JudetID { get; set; }
        public Judet Judet { get; set; }
    }
}
