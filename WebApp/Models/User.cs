﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class User
    {
        [Key]
        public int No { get; set; }

        [Required(ErrorMessage ="Please input User Name")]
        //[Required]
        public string Name { get; set; }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
