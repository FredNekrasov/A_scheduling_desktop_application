using Model.entities.date;
using Model.entitiesForExcel;

namespace SchedulingApp.mappers.implementation;

public class MapToWeekXLSX : IMapToXLSX<WeekXLSX, Week>
{
    public WeekXLSX ToXLSX(Week week)
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
    public List<WeekXLSX> ToXLSXList(List<Week> weeks)
    {
        List<WeekXLSX> list = [];
        foreach (Week week in weeks)
        {
            list.Add(ToXLSX(week));
        }
        return list;
    }
}
