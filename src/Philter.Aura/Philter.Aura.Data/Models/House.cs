
namespace Philter.Aura.Data.Models;


public class House
{
    [Key]
    public int HouseId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(1000)]
    [DataType(DataType.MultilineText)]
    public string Address { get; set; } = null!;

    [MaxLength(50)]
    [Phone]
    [Display(Name = "Main Phone Number", Description = "The main phone number to reach the house")]
    public string? MainPhone { get; set; }

    [MaxLength(50)]
    [Phone]
    [Display(Name = "Alternate Phone Number", Description = "An alternate phone number to reach the house")]
    public string? AltPhone { get; set; } = null!;

    [ManyToMany("AuraUsers", FarNavigationProperty = nameof(HouseManager.AuraUser))]
    public ICollection<HouseManager> HouseManagers { get; set; } = new List<HouseManager>();

    [InverseProperty(nameof(Room.House))]
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}

