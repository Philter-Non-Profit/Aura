namespace Philter.Aura.Data.Models;


public class Room
{
    [Key]
    public int RoomId { get; set; }

    public int HouseId { get; set; }

    public House House { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [DataType(DataType.MultilineText)]
    public string? Notes { get; set; }
}