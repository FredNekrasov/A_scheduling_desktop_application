namespace Model.validation.audiences;

public class CheckAudienceData : ISeatsNumberValidation, IStudentNumberValidation, IAudienceNumberValidation
{
    public bool ValidateAudienceNumber(string audienceNumber)
    {
        if (string.IsNullOrEmpty(audienceNumber) || string.IsNullOrWhiteSpace(audienceNumber)) return false; else return true;
    }
    public bool ValidateSeatsNumber(int? seatsNumber)
    {
        if (seatsNumber == null || seatsNumber <= 0) return false; else return true;
    }
    public bool ValidateStudentNumber(int? studentNumber)
    {
        if (studentNumber == null || studentNumber < 0 || studentNumber > 40) return false; else return true;
    }
}
