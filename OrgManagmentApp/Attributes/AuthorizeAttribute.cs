namespace OrgManagmentApp.Attributes;

public class AuthorizeAttribute : Attribute
{
    public string Role { get; set; }

    public AuthorizeAttribute(string role)
    {
        Role = role;
    }
}