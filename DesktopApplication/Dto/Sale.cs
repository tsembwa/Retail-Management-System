using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopApplication.Dto;

public class Sale
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SaleId { get; set; }

    [Required] public int ItemId { get; set; }
    [Required] public int EmployeeId { get; set; }
    
    [Required] public DateTime Date { get; set; }
    
    [Required, MinLength(1), MaxLength(100)] public required string ReceiptId { get; set; }
    
}