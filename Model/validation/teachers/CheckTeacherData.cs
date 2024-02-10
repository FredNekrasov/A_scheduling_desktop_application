namespace Model.validation.teachers;

public class CheckTeacherData : IValidationName, IValidationSurname, IValidationPatronymic
{
    public bool ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) return false; else return true;
    }
    public bool ValidatePatronymic(string patronymic)
    {
        if (string.IsNullOrEmpty(patronymic) || string.IsNullOrWhiteSpace(patronymic)) return false; else return true;
    }
    public bool ValidateSurname(string surname)
    {
        if (string.IsNullOrEmpty(surname) || string.IsNullOrWhiteSpace(surname)) return false; else return true;
    }
}
