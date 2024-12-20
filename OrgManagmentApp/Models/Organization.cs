namespace OrgManagmentApp.Models;

public class Organization
{
    public int ID { get; set; }

    public required string Name { get; set; }
        
    public required string Email { get; set; }
        
    public required string PhoneNumber { get; set; }
}