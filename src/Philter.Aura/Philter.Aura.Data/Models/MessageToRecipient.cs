using System;

namespace Philter.Aura.Data.Models;
public enum MessageStatusEnum
{
    Recieved = 1,
    Failed = 2,
    InProgress = 3,
}

public class MessageToRecipient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long MessageToRecipientId { get; set; } 
    [Required]
    public long MessageId { get; set; }
    [Required]
    public long RecipientId { get; set; }  
    public Recipient? Recipient { get; set; }
    [Display(Name = "Sender Id", Description = "The Message Sender Id")]
    public Guid AuraUserId { get; set; }
    public AuraUser? Sender { get; set; }   
    public MessageStatusEnum StatusId { get; set; }
    public DateTime DateSent { get; set; }  
}

