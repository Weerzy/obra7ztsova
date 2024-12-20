namespace OrgManagmentApp.Models;

public class Organizer
{
    public int ID { get; set; }

    public string LastName { get; set; }
        
    public string FirstName { get; set; }
        
    public string MiddleName { get; set; }

    public int OrganizationID { get; set; }
    public Organization Organization { get; set; }
        
    public string Email { get; set; }
        
    public string PhoneNumber { get; set; }
}