namespace Model.entities.date;

public class DayEntity
{
    public int ID { get; set; }
    public string DayOfWeek { get; set; } = string.Empty;
    public int? Pair1 { get; set; }
    public int? Pair2 { get; set; }
    public int? Pair3 { get; set; }
    public int? Pair4 { get; set; }
    public int? Pair5 { get; set; }
    public int? Pair6 { get; set; }
    public int? Pair7 { get; set; }
    public Week Week { get; set; }
}
