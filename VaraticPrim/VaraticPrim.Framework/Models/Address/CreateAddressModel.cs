namespace VaraticPrim.Framework.Models.Address;

public class CreateAddressModel
{
    public string? Street      { get; set; }
    public string? HouseNr     { get; set; }
    public string? Block       { get; set; }
    public string? Entrance    { get; set; }
    public string? ApartmentNr { get; set; }
    public string? Locality    { get; set; }
    public string? District    { get; set; }
    public string? PostalCode  { get; set; }
    public string? Country     { get; set; }
}