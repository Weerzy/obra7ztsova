namespace OrgManagmentApp.Models;

public class EventTicketLevel
{
    public int ID { get; set; }

    public int EventID { get; set; }
    public Event Event { get; set; }

    public int LevelID { get; set; }
    public Level Level { get; set; }

    public decimal Price { get; set; }
}