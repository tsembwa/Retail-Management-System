using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopApplication.Dto;

public class Supplier
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SupplierId { get; set; }
    
    [Required, MinLength(1), MaxLength(100)] public required string Name { get; set; }
    
    [Required, EmailAddress] public required string Email { get; set; }
    [Required, MinLength(10), MaxLength(10)] public required string Phone { get; set; }
}