using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public  class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Provide category name")]
        [StringLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }
    }
}
