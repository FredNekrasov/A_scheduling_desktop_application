using Model.entities.room;
using Model.entitiesForExcel;

namespace SchedulingApp.converter;

public class MapToAudienceXLSX
{
    public static AudienceXLSX ToAudienceXLSX(Audience audience)
    {
        return new AudienceXLSX
        {
            AudienceNumber = audience.AudienceNumber,
            SeatsNumber = audience.SeatsNumber,
            AudienceType = audience.AudienceType.TypeName,
            StudentNumber = audience.StudentNumber
        };
    }
}
