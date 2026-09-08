using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopApplication.Dto;

public class Item
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ItemId { get; set; }

    [Required] public int SupplierId { get; set; }
    [Required] public int Quantity { get; set; }
    
    [Required, MinLength(1), MaxLength(100)] public required string Name { get; set; }
    [Required, MinLength(1), MaxLength(100)] public required string Type { get; set; }
    [Required, MinLength(1), MaxLength(100)] public required string Brand { get; set; }

    [Required] public decimal Price { get; set; }
    [Required] public decimal Discount { get; set; }
}