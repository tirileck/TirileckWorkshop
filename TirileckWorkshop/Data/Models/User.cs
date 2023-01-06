namespace TirileckWorkshop.Data.Models;

public class User
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string ModdleName { get; set; }

    public string Position { get; set; }
    
    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public Workshop Workshop { get; set; }
    public long? WorkshopId { get; set; }

    public ICollection<Role> Roles { get; set; }
}