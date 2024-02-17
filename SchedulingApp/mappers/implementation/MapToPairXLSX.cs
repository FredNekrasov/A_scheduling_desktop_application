using Model.entities;
using Model.entitiesForExcel;

namespace SchedulingApp.mappers.implementation
{
    public class MapToPairXLSX : IMapToXLSX<PairXLSX, PairEntity>
    {
        public PairXLSX ToXLSX(PairEntity pair)
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
        public List<PairXLSX> ToXLSXList(List<PairEntity> pairs)
        {
            List<PairXLSX> list = [];
            foreach (PairEntity pair in pairs)
            {
                list.Add(ToXLSX(pair));
            }
            return list;
        }
    }
}
