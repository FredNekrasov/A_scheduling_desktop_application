namespace Model.validation.groups;

public class CheckGroupData : IValidationGroupNumber, IValidationShortGN, IValidationStudentNumber
{
    public bool ValidateGroupNumber(string groupNumber)
    {
        if (string.IsNullOrEmpty(groupNumber) || string.IsNullOrWhiteSpace(groupNumber)) return false; else return true;
    }
    public bool ValidateShortGN(string shortNumber)
    {
        if (string.IsNullOrEmpty(shortNumber) || string.IsNullOrWhiteSpace(shortNumber) || !shortNumber.Contains('-') || shortNumber.Length < 3) return false; else return true;
    }
    public bool ValidateStudentNumber(int? studentNumber)
    {
        if (studentNumber == null || studentNumber < 0 || studentNumber > 40) return false; else return true;
    }
}
