namespace VaraticPrim.Domain.Entities;

public class AddressEntity : BaseEntity
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
    public int LocationId { get; set; }

    public virtual LocationEntity Location { get; set; }
}