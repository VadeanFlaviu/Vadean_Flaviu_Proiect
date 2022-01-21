using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vadean_Flaviu_Proiect.Models
{
    public class Persoana
    {
        public int ID { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "CNP-ul trebuie sa contina doar cifre"), Required, StringLength(13, ErrorMessage = "CNP-ul trebuie sa contina 13 cifre", MinimumLength = 13)]
        public string CNP { get; set; }
        [RegularExpression(@"^[A-Z][A-Za-z\s\-]+$", ErrorMessage = "Numele persoanei trebuie sa inceapa cu litera mare, poate contine 'spatiu' sau caracterul '-'"), Required, StringLength(100, MinimumLength = 3)]
        [Display(Name = "Nume")]
        public string NumePersoana { get; set; }
        [RegularExpression(@"^[A-Za-z0-9\-.,\s]+$", ErrorMessage = "Adresa trebuie sa contina doar litere, cifre, sau caracterele: '-', ',' , '.', 'spatiu'"), Required, StringLength(255, MinimumLength = 3)]
        public string Adresa { get; set; }
        [Display(Name = "Sectie Votare")]
        public int SectieVotareID { get; set; }
        public SectieVotare SectieVotare { get; set; }
    }
}
