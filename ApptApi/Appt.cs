public class Appt
{
    public int Id { get; set; }
    public string? PetName { get; set; }
    public DateTime Date {get; set;}
    public string? OwnerName {get; set;}
    public string? OwnerAddress {get; set;}
    public bool IsArchived { get; set; }
    public string? Secret { get; set; }

}