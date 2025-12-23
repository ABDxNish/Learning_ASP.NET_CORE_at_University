using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabTaskFinal.DTOs
{
    public class CategoryDTO
    {
       
        [Required]
        [StringLength(50,ErrorMessage ="Name must not exceeds 50 character")]
        public string Name { get; set; }
    }
}
