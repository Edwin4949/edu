﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Designation
    {
        
            [Key]
            public int Id { get; set; }

            [StringLength(100, MinimumLength = 3)]
            public string? DesignationTypes { get; set; }
        
    }
}
