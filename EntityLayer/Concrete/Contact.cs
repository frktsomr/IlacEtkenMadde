using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(500)]
        public string ContactMessage { get; set; }
        [StringLength(500)]
        public string ContactSubject { get; set; }
        
        [StringLength(500)]
        public string ContactSelfie { get; set; }
        public DateTime ContactDate { get; set; }

        public string UserMail { get; set; }
        public int? UserID { get; set; }
        public virtual User User { get; set; }

    }
}
