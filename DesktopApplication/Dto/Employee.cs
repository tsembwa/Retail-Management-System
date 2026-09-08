using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopApplication.Dto;

public class Employee
{
   [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public int EmployeeId { get; set; }
   
   [Required(ErrorMessage = "A firstname is required."), 
    MinLength(1, ErrorMessage = "Firstname must have a at least 1 character"), 
    MaxLength(100, ErrorMessage = "Firstname cannot have more than 100 characters")]
   public required string FirstName { get; set; }
   
   [Required(ErrorMessage = "A lastname is required."), 
    MinLength(1, ErrorMessage = "Lastname must have a at least 1 character"), 
    MaxLength(100, ErrorMessage = "Lastname cannot have more than 100 characters")]
   public required string LastName { get; set; }
   
   [Required(ErrorMessage = "A username is required."), 
    MinLength(1, ErrorMessage = "Username must have a at least 1 character"), 
    MaxLength(100, ErrorMessage = "Username cannot have more than 100 characters")]
   public required string Username { get; set; }
   
   [Required(ErrorMessage = "A password is required."), 
    MinLength(1, ErrorMessage = "Password must have a at least 1 character"), 
    MaxLength(100, ErrorMessage = " Password cannot have more than 100 characters")]
   public required string Password { get; set; }
   
   [EmailAddress(ErrorMessage = "Enter a valid email address"), 
    MaxLength(255, ErrorMessage = "Email address cannot be longer than 255 characters")] 
   public required string Email { get; set; }
   
   [Required(ErrorMessage = "A phone number is required"),
    MinLength(10, ErrorMessage = "Enter a valid phone number"), 
    MaxLength(10, ErrorMessage = "Enter a valid phone number")] 
   public required string Phone { get; set; }
   
   [Required(ErrorMessage = "A access code is required"),
    MinLength(5, ErrorMessage = "Enter a valid access code"), 
    MaxLength(5, ErrorMessage = "Enter a valid access code")] 
   public required string Access { get; set; }
}