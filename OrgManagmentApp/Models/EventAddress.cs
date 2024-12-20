namespace OrgManagmentApp.Models;

public class EventAddress
{
    public int ID { get; set; }

    public required string Address { get; set; }
        
    public required string VenueNumber { get; set; }
        
    public int Capacity { get; set; }
}