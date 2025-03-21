using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeManagement.Models;

/*
TaskID: Int (Primary)
DelegatorID: Int (Foreign Key)
TaskReceiverID: Int (Foreign)
Task: String
DateTimeCompleted: DateTime
*/

public class Tasks {
    [Key]
    public int ID {get; set;}
    
    [Required]
    [ForeignKey("User")]    // Foreign Key
    public int DelegatorID {get; set;}

    [Required]
    [ForeignKey("User")]    // Foreign Key
    public int TaskReceiverID {get; set;}
    
    [Required]
    public string Task {get; set;}
    
    public DateTime DateTimeCompleted {get; set;}
}