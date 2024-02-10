using Model.entities;
using Model.repositories;
using Model.validation.subjects;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation;

public class SaveSubject(
    IConsultationHoursValidation consultationHoursValidation,
    ILectureHoursValidation lectureHoursValidation,
    IPracticeHoursValidation practiceHoursValidation,
    ISubjectNameValidation subjectNameValidation,
    ITotalHoursValidation totalHoursValidation,
    ITypeOfCertificationValidation typeOfCertificationValidation
) : ISaveVM<Subject>
{
    private readonly IRepository<Subject> _repository = RepositoryModule<Subject>.GetRepository("Subjects");
    private readonly IConsultationHoursValidation _consultationHoursValidation = consultationHoursValidation;
    private readonly ILectureHoursValidation _lectureHoursValidation = lectureHoursValidation;
    private readonly IPracticeHoursValidation _practiceHoursValidation = practiceHoursValidation;
    private readonly ISubjectNameValidation _subjectNameValidation = subjectNameValidation;
    private readonly ITotalHoursValidation _totalHoursValidation = totalHoursValidation;
    private readonly ITypeOfCertificationValidation _typeOfCertificationValidation = typeOfCertificationValidation;
    public async Task<string> SaveAsync(Subject obj)
    {
        StringBuilder errors = new();
        bool result = _subjectNameValidation.ValidateSubjectName(obj.SubjectName);
        if (result == false) errors.AppendLine("Введено неправильное название предмета");
        result = _lectureHoursValidation.ValidateLectureHours(obj.LectureHours);
        if (result == false) errors.AppendLine("Лекционные часы введены неправильно");
        result = _practiceHoursValidation.ValidatePracticHours(obj.PracticHours);
        if (result == false) errors.AppendLine("Практические часы введены неправильно");
        result = _consultationHoursValidation.ValidateConultationHours(obj.ConsultationHours);
        if (result == false) errors.AppendLine("Консультационные часы введены неправильно");
        result = _totalHoursValidation.ValidateTotalHours(obj.TotalHours);
        if (result == false) errors.AppendLine("Общее количество часов введено неправильно");
        result = _typeOfCertificationValidation.ValidateTypeOfCertification(obj.TypeOfCertification);
        if (result == false) errors.AppendLine("Тип аттестации введен неправильно");
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
