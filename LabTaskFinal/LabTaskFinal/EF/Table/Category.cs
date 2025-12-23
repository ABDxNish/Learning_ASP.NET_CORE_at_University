using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabTaskFinal.EF.Table
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }

       
    }
}
