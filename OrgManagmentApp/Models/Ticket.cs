namespace OrgManagmentApp.Models;

public class Ticket
{
    public int ID { get; set; }

    public int EventID { get; set; }
    public Event Event { get; set; }

    public int ParticipantID { get; set; }
    public User Participant { get; set; }

    public int LevelID { get; set; }
    public EventTicketLevel Level { get; set; }

    public decimal Cost { get; set; }
}