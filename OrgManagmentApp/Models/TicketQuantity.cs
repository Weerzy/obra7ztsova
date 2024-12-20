namespace OrgManagmentApp.Models;

public class TicketQuantity
{
    public int ID { get; set; }

    public int LevelID { get; set; }
    public Level Level { get; set; }

    public int EventID { get; set; }
    public Event Event { get; set; }

    public int MaxQuantity { get; set; }
}