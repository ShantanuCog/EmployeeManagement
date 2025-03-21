using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeManagement.Models;
/*
Rota Model:
-RequestID: ID of the requested time off
-UserID: Determine which User
-TimeRequestedFrom: Date from
-TimeRequestedTo: Date to
-Status: Pending/Approved/Denied (Enum) (Default:Pending)
-ApproverID: Who made the status (Approved/Denied)
-DateCreated
-DateUpdated: When status changes -> Approved/Denied
*/

public class Rota {
    [Key]
    public int ID {get; set;}
    
    [Required]
    [ForeignKey("User")]    // Foreign Key
    public int UserID {get; set;}
    
    [Required]
    [ForeignKey("User")]    // Foreign Key
    public int ApproverID {get; set;}
    
    [Required]
    public DateTime TimeRequestedFrom {get; set;}
    
    [Required]
    public DateTime TimeRequestedTo {get; set;}
    
    [Required]
    public TimeOffStatus Status {get; set;}
    
    public DateTime DateCreated {get; set;}
    
    public DateTime DateUpdated {get; set;}
}