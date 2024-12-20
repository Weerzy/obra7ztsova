namespace OrgManagmentApp.Models;

public class Event
{
    public int ID { get; set; }

    public required string Name { get; set; }
    public DateTime Date { get; set; }

    public int EventCategoryID { get; set; }
    public required EventCategory EventCategory { get; set; }

    public int EventAddressID { get; set; }
    public required EventAddress EventAddress { get; set; }

    public int OrganizerID { get; set; }
    public required Organizer Organizer { get; set; }
    
    public required ICollection<EventTicketLevel> TicketLevels { get; set; }
}