﻿using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalApi.Models
{
    public partial class Login
    {
        public int IdLogin { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdPatient { get; set; }
        public string Login1 { get; set; }
        public string Password { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Patient IdPatientNavigation { get; set; }
    }
}
