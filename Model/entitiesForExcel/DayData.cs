using Model.entities;
using Model.entities.date;

namespace Model.entitiesForExcel
{
    public class DayData
    {
        public int ID { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public PairEntity? Pair1 { get; set; }
        public PairEntity? Pair2 { get; set; }
        public PairEntity? Pair3 { get; set; }
        public PairEntity? Pair4 { get; set; }
        public PairEntity? Pair5 { get; set; }
        public PairEntity? Pair6 { get; set; }
        public PairEntity? Pair7 { get; set; }
        public Week Week { get; set; }
    }
}
