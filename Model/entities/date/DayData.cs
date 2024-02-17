namespace Model.entities.date
{
    public class DayData//to display data on windows
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
