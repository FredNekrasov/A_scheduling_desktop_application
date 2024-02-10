using Model.entities.room;

namespace Model.entities;

public class PairEntity
{
    public int PairID { get; set; }
    public Squad Group { get; set; }
    public Audience Audience { get; set; }
    public Subject Subject { get; set; }
    public Teacher Teacher { get; set; }
}
