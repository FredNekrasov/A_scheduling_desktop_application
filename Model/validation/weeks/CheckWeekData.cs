namespace Model.validation.weeks;

public class CheckWeekData : IWeekNumberValidation
{
    public bool ValidateWeekNumber(int? weekNumber)
    {
        if (weekNumber == null || weekNumber <= 0 || weekNumber > 30) return false; else return true;
    }
}
