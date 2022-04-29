﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        [StringLength(100)]
        public string HeadingName { get; set; }

        public DateTime HeadingDate { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }



        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
