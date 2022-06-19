namespace BrownOrchid.Gateways.Portal.Static;

public static class Endpoints
{
    public const string CheckDealerPassword = "/dealer/login";
    public const string GetAllDealers = "/dealer/all";
    
    public const string GetActiveDiscounts = "/discount/allactive";
    public const string CreateDiscount = "/discount/create";
    public const string ApproveDiscount = "/discount/approve";
    public const string AllDiscounts = "/discount/all";
    public const string AllWaitingDiscounts = "/discount/allwaiting";
    
    
    public const string AllPosTerminals = "/posterminal/all";
    
    
    public const string CheckEmployeePassword = $"/bankemployee/login";
    
    public const string CheckClientPassword = $"/client/login";
    public const string CreateClient = "/client/register";
}