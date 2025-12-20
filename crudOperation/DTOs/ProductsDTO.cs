using System.ComponentModel.DataAnnotations;

namespace crudOperation.DTOs
{
    public class ProductsDTO
    {
        
        public int Pid { get; set; }
       
        [Required] 
        public string ProductName { get; set; } = null!;
        [Required(ErrorMessage ="Product must have a type")]
        [StringLength(50,ErrorMessage ="Type must not exceeds 50 character")]
        public string ProductType { get; set; } = null!;
        [Required]
        public string Quantity { get; set; } = null!;
        [Required(ErrorMessage ="Enter the price")]
        public int Price { get; set; }
    }
}
