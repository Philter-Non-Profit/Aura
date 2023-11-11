
using System;
using System.Collections.Generic;

namespace Philter.Aura.Data.Models;


public class AuraUser
{
    [Key]
    [Display(Name = "User ID", Description = "Azure Object Id")]
    public Guid AuraUserId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public DateTimeOffset? LastLogin { get; set; }

    [ManyToMany("Houses", FarNavigationProperty = nameof(HouseManager.House))]
    public ICollection<HouseManager> HouseManagers { get; set; } = new List<HouseManager>();

    public ICollection<Message> Messages { get; set; } = new List<Message>();



#nullable restore


}
