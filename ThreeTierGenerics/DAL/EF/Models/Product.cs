using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30,ErrorMessage ="Name should not exceeds 30 characters")]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }
        [Required]
        public decimal price {  get; set; }
        [Required]
        public int qty { get; set; }
        [ForeignKey("cat")]
        [Required(ErrorMessage = "Category id must needed")]
        public int CId { get; set; }
        public virtual Category cat { get; set; }

    }
}
