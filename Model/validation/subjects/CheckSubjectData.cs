namespace Model.validation.subjects;

public class CheckSubjectData : ISubjectNameValidation, ILectureHoursValidation,
    IPracticeHoursValidation, ITotalHoursValidation,
    IConsultationHoursValidation, ITypeOfCertificationValidation
{
    public bool ValidateConultationHours(int? consultationHours)
    {
        if (consultationHours == null || consultationHours < 0 || consultationHours > 4) return false; else return true;
    }
    public bool ValidateLectureHours(int? lectureHours)
    {
        if (lectureHours == null || lectureHours < 0) return false; else return true;
    }
    public bool ValidatePracticHours(int? practicHours)
    {
        if (practicHours == null || practicHours < 0) return false; else return true;
    }
    public bool ValidateSubjectName(string subjectName)
    {
        if (string.IsNullOrEmpty(subjectName) || string.IsNullOrWhiteSpace(subjectName)) return false; else return true;
    }
    public bool ValidateTotalHours(int? totalHours)
    {
        if (totalHours == null || totalHours <= 0) return false; else return true;
    }
    public bool ValidateTypeOfCertification(string typeOfCertification)
    {
        if (string.IsNullOrEmpty(typeOfCertification) || string.IsNullOrWhiteSpace(typeOfCertification)) return false; else return true;
    }
}
