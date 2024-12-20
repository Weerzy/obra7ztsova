namespace OrgManagmentApp.Models;

public class Organizer
{
    public int ID { get; set; }

    public required string LastName { get; set; }
        
    public required string FirstName { get; set; }
        
    public required string MiddleName { get; set; }

    public int OrganizationID { get; set; }
    public required Organization Organization { get; set; }
        
    public required string Email { get; set; }
        
    public required string PhoneNumber { get; set; }
}