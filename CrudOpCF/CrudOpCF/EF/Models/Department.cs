using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOpCF.EF.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Column(TypeName ="VARCHAR")]
        public string Name { get; set; }
    }
}
