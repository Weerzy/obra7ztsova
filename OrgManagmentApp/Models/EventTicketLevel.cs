namespace OrgManagmentApp.Models;

public class EventTicketLevel
{
    public int ID { get; set; }

    public int EventID { get; set; }
    public required Event Event { get; set; }

    public int LevelID { get; set; }
    public required Level Level { get; set; }

    public decimal Price { get; set; }
}