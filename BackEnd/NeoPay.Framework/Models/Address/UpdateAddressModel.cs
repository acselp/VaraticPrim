namespace NeoPay.Framework.Models.Address;

public class UpdateAddressModel
{
    public int     Id         { get; set; }
    public string? Country    { get; set; }
    public string? Region     { get; set; }
    public string? City       { get; set; }
    public string? Street     { get; set; }
    public string? House      { get; set; }
    public string? Entrance   { get; set; }
    public string? Apartment  { get; set; }
    public string? PostalCode { get; set; }
    public int     CustomerId { get; set; }
}
