using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vadean_Flaviu_Proiect.Models
{
    public class SectieVotare
    {
        [Display(Name = "Numar Sectie Votare")]
        public int ID { get; set; }
        [RegularExpression(@"^[A-Za-z0-9\-.,\s]+$", ErrorMessage = "Adresa trebuie sa contina doar litere, cifre, sau caracterele: '-', ',' , '.', 'spatiu'"), Required, StringLength(255, MinimumLength = 3)]
        public string Adresa { get; set; }
        [Display(Name = "Localitate")]
        public int LocalitateID { get; set; }
        public Localitate Localitate { get; set; }
    }
}
