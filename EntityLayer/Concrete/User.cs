using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserSurname { get; set; }
        [StringLength(100)]
        public string UserMail { get; set; }
        [StringLength(100)]
        public string UserPassword { get; set; }
        [StringLength(500)]
        public string UserPhoto { get; set; }

        public bool UserStatus { get; set; }

        public bool UserActive { get; set; }

        public ICollection<Content> Contents { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Contact> Contacts { get; set; }

    }
}
