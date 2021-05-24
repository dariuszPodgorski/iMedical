using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Pacjent
    {
        public Pacjent()
        {
            Badanies = new HashSet<Badanie>();
            Logins = new HashSet<Login>();
            Skierowanies = new HashSet<Skierowanie>();
            Wizyta = new HashSet<Wizytum>();
        }

        public int IdPacjent { get; set; }
        public string Imie { get; set; }
        public string DrugieImie { get; set; }
        public string Nazwisko { get; set; }
        public string Plec { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string Pesel { get; set; }
        public string KrajZameldowania { get; set; }
        public string MiejscowoscZameldowania { get; set; }
        public string KodPocztowyZameldowania { get; set; }
        public string UlicaZameldowania { get; set; }
        public string NrBudynkuZameldowania { get; set; }
        public string NrLokaluZameldowania { get; set; }
        public string MiejscowoscZamieszkania { get; set; }
        public string KodPocztowyZamieszkania { get; set; }
        public string UlicaZamieszkania { get; set; }
        public string NrBudynkuZamieszkania { get; set; }
        public string NrLokaluZamieszkania { get; set; }
        public string KrajZamieszkania { get; set; }
        public string Email { get; set; }
        public string NrKontaktowy { get; set; }
        public string NrUbezpieczenia { get; set; }

        public virtual ICollection<Badanie> Badanies { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Skierowanie> Skierowanies { get; set; }
        public virtual ICollection<Wizytum> Wizyta { get; set; }
    }
}
