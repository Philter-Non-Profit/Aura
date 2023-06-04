namespace Philter.Aura.Data.Models;

#nullable disable

public class AuraUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Display(Name = "User ID", Description = "A unique user identifying GUID")]
    public Guid AuraUserId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    [Required]
    [MaxLength(200)]
    [EmailAddress]
    public string Email { get; set; }

    public DateTimeOffset? LastLogin { get; set; }

    public List<House> ManagedHouses { get; set; } = new();

#nullable restore


}
