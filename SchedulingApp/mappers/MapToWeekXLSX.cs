using Model.entities.date;
using Model.entitiesForExcel;

namespace SchedulingApp.mappers;

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
    public static List<WeekXLSX> ToWeekXLSXes(List<Week> weeks)
    {
        List<WeekXLSX> list = [];
        foreach (Week week in weeks)
        {
            list.Add(ToWeekXLSX(week));
        }
        return list;
    }
}
