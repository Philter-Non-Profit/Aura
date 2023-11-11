using System.Collections.Generic;

namespace Philter.Aura.Data.Models;
public class Recipient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long RecipientId { get; set; }

    [Required]
    [MaxLength(150)]
    public required string RecipientName { get; set; }

    [Required]
    [MaxLength(150)]
    [Phone]
    public required string RecipientPhoneNumber { get; set; }

    public ICollection<Message> Messages { get; set; } = new List<Message>();
}
