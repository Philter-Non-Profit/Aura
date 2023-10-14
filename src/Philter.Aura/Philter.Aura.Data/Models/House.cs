
namespace Philter.Aura.Data.Models;

#nullable disable

public class House
{
    [Key]
    public int HouseId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    [Required]
    [MaxLength(1000)]
    [DataType(DataType.MultilineText)]
    public string Address { get; set; }

    [MaxLength(50)]
    [Phone]
    [Display(Name = "Main Phone Number", Description = "The main phone number to reach the house")]
    public string MainPhone { get; set; }

    [MaxLength(50)]
    [Phone]
    [Display(Name = "Alternate Phone Number", Description = "An alternate phone number to reach the house")]
    public string AltPhone { get; set; }

    public List<AuraUser> Managers { get; set; } = new();

    [InverseProperty(nameof(Room.House))]
    public List<Room> Rooms { get; set; } = new();
}

