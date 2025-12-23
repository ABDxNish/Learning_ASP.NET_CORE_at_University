using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabTaskFinal.EF.Table
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="VARCHAR")]
        [StringLength(50)]
       public string Name { get; set; }
        public int Price { get; set; }
        [ForeignKey("Ctg")]
        public int Cid {  get; set;     }
        public virtual Category Ctg {  get; set; }

    }
}
