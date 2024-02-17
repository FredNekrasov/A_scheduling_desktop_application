using Model.entities;
using Model.entitiesForExcel;

namespace SchedulingApp.mappers
{
    public class MapToPairXLSX
    {
        public static PairXLSX ToPairXLSX(PairEntity pair)
        {
            return new PairXLSX
            {
                PairID = pair.PairID,
                Subject = pair.Subject.SubjectName,
                Teacher = $"{pair.Teacher.Surname} {pair.Teacher.Name} {pair.Teacher.Patronymic}",
                Group = pair.Group.ShortNumber,
                Audience = pair.Audience.AudienceNumber
            };
        }
        public static List<PairXLSX> ToPairXLSXes(List<PairEntity> pairs)
        {
            List<PairXLSX> list = [];
            foreach (PairEntity pair in pairs)
            {
                list.Add(ToPairXLSX(pair));
            }
            return list;
        }
    }
}
