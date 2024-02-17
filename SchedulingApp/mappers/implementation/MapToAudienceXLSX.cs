using Model.entities.room;
using Model.entitiesForExcel;

namespace SchedulingApp.mappers.implementation;

public class MapToAudienceXLSX : IMapToXLSX<AudienceXLSX, Audience>
{
    public AudienceXLSX ToXLSX(Audience audience)
    {
        return new AudienceXLSX
        {
            AudienceNumber = audience.AudienceNumber,
            SeatsNumber = audience.SeatsNumber,
            AudienceType = audience.AudienceType.TypeName,
            StudentNumber = audience.StudentNumber
        };
    }
    public List<AudienceXLSX> ToXLSXList(List<Audience> audiences)
    {
        List<AudienceXLSX> list = [];
        foreach (Audience audience in audiences)
        {
            list.Add(ToXLSX(audience));
        }
        return list;
    }
}
