using Model.entities;
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
                Pair1 = GetID(data.Pair1),
                Pair2 = GetID(data.Pair2),
                Pair3 = GetID(data.Pair3),
                Pair4 = GetID(data.Pair4),
                Pair5 = GetID(data.Pair5),
                Pair6 = GetID(data.Pair6),
                Pair7 = GetID(data.Pair7),
            };
        }
        private static int? GetID(PairEntity? pairEntity) => pairEntity?.PairID;
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
