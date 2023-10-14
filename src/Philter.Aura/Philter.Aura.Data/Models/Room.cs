namespace Philter.Aura.Data.Models;

#nullable disable

public class Room
{
    [Key]
    public int RoomId { get; set; }

    public int HouseId { get; set; }

    public House House { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.MultilineText)]
    public string Notes { get; set; }
}