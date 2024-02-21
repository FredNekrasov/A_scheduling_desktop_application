using Model.entities;
using Model.repositories;
using Model.validation.subjects;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation;

public class SaveSubject() : VMBase, ISaveVM<Subject>
{
    private readonly IRepository<Subject> _repository = RepositoryModule<Subject>.GetRepository("Subjects");
    private readonly ISubjectNameValidation subjectNameValidation = new CheckSubjectData();
    private readonly ILectureHoursValidation lectureHoursValidation = new CheckSubjectData();
    private readonly IPracticeHoursValidation practiceHoursValidation = new CheckSubjectData();
    private readonly IConsultationHoursValidation consultationHoursValidation = new CheckSubjectData();
    private readonly ITotalHoursValidation totalHoursValidation = new CheckSubjectData();
    private readonly ITypeOfCertificationValidation typeOfCertificationValidation = new CheckSubjectData();
    public async Task<string> SaveAsync(Subject obj)
    {
        StringBuilder errors = new();
        bool result = subjectNameValidation.ValidateSubjectName(obj.SubjectName);
        if (result == false) errors.AppendLine("Введено неправильное название предмета");
        result = lectureHoursValidation.ValidateLectureHours(obj.LectureHours);
        if (result == false) errors.AppendLine("Лекционные часы введены неправильно");
        result = practiceHoursValidation.ValidatePracticHours(obj.PracticHours);
        if (result == false) errors.AppendLine("Практические часы введены неправильно");
        result = consultationHoursValidation.ValidateConultationHours(obj.ConsultationHours);
        if (result == false) errors.AppendLine("Консультационные часы введены неправильно");
        result = totalHoursValidation.ValidateTotalHours(obj.TotalHours);
        if ((result == false) || (obj.TotalHours != (obj.LectureHours + obj.PracticHours + obj.ConsultationHours))) errors.AppendLine("Общее количество часов введено неправильно");
        result = typeOfCertificationValidation.ValidateTypeOfCertification(obj.TypeOfCertification);
        if (result == false) errors.AppendLine("Тип аттестации введен неправильно");
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
