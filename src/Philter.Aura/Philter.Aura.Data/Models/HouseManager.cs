using System;

namespace Philter.Aura.Data.Models;

[Index(nameof(HouseId), nameof(AuraUserId), IsUnique = true)]
public class HouseManager
{
    [Key]
    public int HouseManagerId { get; set; }
    public int HouseId { get; set; }
    public House House { get; set; } = null!;

    public Guid AuraUserId { get; set; }
    public AuraUser AuraUser { get; set; } = null!;
}