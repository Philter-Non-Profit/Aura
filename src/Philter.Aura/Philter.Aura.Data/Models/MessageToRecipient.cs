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
    public long MessageId { get; set; }
    public Message? Message { get; set; }
    [Required]
    public string TwilioMessageSid {get; set; }
    
    [Required]
    public long RecipientId { get; set; }  
    public Recipient? Recipient { get; set; }

    [Required]
    public Guid SenderId { get; set; }
    public AuraUser? Sender { get; set; }   
    public MessageStatusEnum StatusId { get; set; }
    public DateTime DateSent { get; set; }  
}

