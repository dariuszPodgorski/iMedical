﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 

namespace iMedicalApi.Models
{
    public class CreatePriceListDto
    {
        public int IdPriceList { get; set; }
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
