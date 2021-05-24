using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Login
    {
        public int IdLogin { get; set; }
        public int? IdPacjent { get; set; }
        public int? IdPracownik { get; set; }
        public string Login1 { get; set; }
        public string Haslo { get; set; }

        public virtual Pacjent IdPacjentNavigation { get; set; }
        public virtual Pracownik IdPracownikNavigation { get; set; }
    }
}
