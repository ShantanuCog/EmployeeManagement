using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.Models;

/*
Create Employee Management Application that allows its users to do 3 key things:
-Rota (Request Time off, Approve/Deny Time off)
-Feedback (Give/Receive Feedback)
-Tasks (Allocate/Receive Tasks)
*/

public class User {
  [Key]
  public int ID {get; set;}   // Primary Key
  
  [Required]
  [StringLength(50)]
  public string Username {get; set; }
  
  [Required]
  public string Password {get; set; }
  
  [Required]
  public string Email {get; set; }
  
  [Required]
  public UserRole Role {get; set; }
  
  [Required]
  public DateTime DateCreated {get; set;}
  
  public DateTime DateUpdated {get; set;}
}
