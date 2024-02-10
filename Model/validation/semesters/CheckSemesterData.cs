namespace Model.validation.semesters;

public class CheckSemesterData : IIsEvenValidation, IYearValidation
{
    public bool IsEvenValidation(bool? isEven)
    {
        if (isEven == null) return false; else return true;
    }
    public bool ValidateYear(int? year)
    {
        if (year == null || year < 2000 || year > 2500) return false; else return true;
    }
}
