using System;
using System.Collections.Generic;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            UserAccounts = new HashSet<UserAccount>();
        }

        public int IdRole { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
