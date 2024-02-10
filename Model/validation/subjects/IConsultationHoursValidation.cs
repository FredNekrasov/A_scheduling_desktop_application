namespace Model.validation.subjects;

public interface IConsultationHoursValidation
{
    bool ValidateConultationHours(int? consultationHours);
}
