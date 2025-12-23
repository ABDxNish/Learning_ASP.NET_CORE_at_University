using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabTaskFinal.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name must not exceeds 50 character")]
        public string Name { get; set; }
        
        [Required]
        public int Price { get; set; }
        [Required(ErrorMessage = "Category Must Require")]
        public int Cid { get; set; }
    }
}
