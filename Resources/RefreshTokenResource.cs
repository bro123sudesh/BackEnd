﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Resources
{
    public class RefreshTokenResource
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string UserEmail { get; set; }
    }
}
