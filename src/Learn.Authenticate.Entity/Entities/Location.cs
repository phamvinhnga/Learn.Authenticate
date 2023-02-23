﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Entities
{
    [Table("Post")]
    public class Location : BaseTreeEntity<int>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
