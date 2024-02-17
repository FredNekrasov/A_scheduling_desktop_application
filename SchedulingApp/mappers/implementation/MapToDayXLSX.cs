using Model.entities.date;
using Model.entitiesForExcel;

namespace SchedulingApp.mappers.implementation
{
    public class MapToDayXLSX : IMapToXLSX<DayXLSX, DayData>
    {
        public DayXLSX ToXLSX(DayData data)
        {
            return new DayXLSX
            {
                DayOfWeek = data.DayOfWeek,
                WeekNumber = data.Week.WeekNumber,
                Pair1 = data.Pair1.PairID,
                Pair2 = data.Pair2.PairID,
                Pair3 = data.Pair3.PairID,
                Pair4 = data.Pair4.PairID,
                Pair5 = data.Pair5.PairID,
                Pair6 = data.Pair6.PairID,
                Pair7 = data.Pair7.PairID,
            };
        }
        public List<DayXLSX> ToXLSXList(List<DayData> dataList)
        {
            List<DayXLSX> list = [];
            foreach (DayData data in dataList)
            {
                list.Add(ToXLSX(data));
            }
            return list;
        }
    }
}
