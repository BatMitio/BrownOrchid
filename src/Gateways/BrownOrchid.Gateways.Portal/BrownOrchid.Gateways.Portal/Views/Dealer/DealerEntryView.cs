namespace BrownOrchid.Gateways.Portal.Views.Dealer;

public class DealerEntryView
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateRegistered { get; set; }

    public DealerEntryView()
    {
    }

    public DealerEntryView(string id, string username, string email, string phoneNumber, DateTime dateRegistered)
    {
        Id = id;
        Username = username;
        Email = email;
        PhoneNumber = phoneNumber;
        DateRegistered = dateRegistered;
    }
}