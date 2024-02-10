namespace Model.entities.room;

public class Audience
{
    public int ID { get; set; }
    public AudienceType AudienceType { get; set; }
    public int SeatsNumber { get; set; }
    public int StudentNumber { get; set; }
    public string AudienceNumber { get; set; } = string.Empty;
}
