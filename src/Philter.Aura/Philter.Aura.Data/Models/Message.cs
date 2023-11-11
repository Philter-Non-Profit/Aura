namespace Philter.Aura.Data.Models;
public class Message
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long MessageId { get; set; }

    [Required]
    [MaxLength(1600)]
    public required string MessageBody { get; set; } 
}
