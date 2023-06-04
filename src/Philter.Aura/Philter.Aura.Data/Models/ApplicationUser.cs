namespace Philter.Aura.Data.Models;

#nullable disable

public class ApplicationUser
{
    public int ApplicationUserId { get; set; }

    [Required]
    public string Name { get; set; }

#nullable restore


}
