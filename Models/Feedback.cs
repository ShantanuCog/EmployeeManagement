using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeManagement.Models;

/*
FeedbackID: Int (Primary)
FeedbackProviderID: Int (Foreign)
FeedbackReceiverID: Int (Foreign)
Feedback: String
DateFeedbackGiven: DateTime
*/

public class Feedback {
    [Key]
    public int ID {get; set;}

    [Required]
    [ForeignKey("User")]    // Foreign Key
    public int FeedbackProviderID {get; set;}

    [Required]
    [ForeignKey("User")]    // Foreign Key
    public int FeedbackReceiverID {get; set;}

    [Required]
    [StringLength(1000)]
    public string FeedbackText {get; set;}

    [Required] // When feedback was given
    public DateTime DateFeedbackGiven {get; set;}
}