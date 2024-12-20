namespace OrgManagmentApp.Models;

public class Event
{
    public int ID { get; set; }

    public string Name { get; set; }
    public DateTime Date { get; set; }

    public int EventCategoryID { get; set; }
    public EventCategory EventCategory { get; set; }

    public int EventAddressID { get; set; }
    public EventAddress EventAddress { get; set; }

    public int OrganizerID { get; set; }
    public Organizer Organizer { get; set; }
    
    public ICollection<EventTicketLevel> TicketLevels { get; set; }
}