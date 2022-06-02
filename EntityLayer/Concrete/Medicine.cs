using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Medicine
    {
        [Key]
        public int MedicineID { get; set; }
        [StringLength(100)]
        public string MedicineName { get; set; }
        [StringLength(1500)]
        public string MedicineProspectus { get; set; }
        [StringLength(1500)]
        public string MedicineRepercussions { get; set; }
        [StringLength(1500)]
        public string MedicineUsage { get; set; }


        public int ActiveIngredientID { get; set; }
        public virtual ActiveIngredient ActiveIngredient { get; set; }

    }
}
