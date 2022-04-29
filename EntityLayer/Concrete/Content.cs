using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(500)]
        public string ContentName { get; set; }
        public DateTime ContentDate { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
