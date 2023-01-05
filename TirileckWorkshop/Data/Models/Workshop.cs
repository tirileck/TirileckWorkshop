namespace TirileckWorkshop.Data.Models;

public class Workshop
{
    public long Id { get; set; }
    public string Address { get; set; }
    
    public ICollection<User> Users { get; set; }
}