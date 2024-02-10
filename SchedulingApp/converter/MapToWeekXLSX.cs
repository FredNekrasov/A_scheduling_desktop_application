using Model.entities.date;
using Model.entitiesForExcel;

namespace SchedulingApp.converter;

public class MapToWeekXLSX
{
    public static WeekXLSX ToWeekXLSX(Week week)
    {
        string semester;
        if (week.Semester.IsEven == true) semester = "1st semester"; else semester = "2ond semester";
        return new WeekXLSX
        {
            WeekNumber = week.WeekNumber,
            Semester = semester,
            Year = week.Semester.Year
        };
    }
}
