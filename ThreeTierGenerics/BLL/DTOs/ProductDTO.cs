using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Name should not exceeds 30 characters")]
        
        public string Name { get; set; }
        [Required(ErrorMessage ="Provide price")]
        public decimal price { get; set; }
        [Required]
        public int qty { get; set; }
       
        [Required(ErrorMessage = "Category id must needed")]
        public int CId { get; set; }
    }
}
