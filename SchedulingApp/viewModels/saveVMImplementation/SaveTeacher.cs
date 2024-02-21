using Model.entities;
using Model.repositories;
using Model.validation.teachers;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation;

public class SaveTeacher() : VMBase, ISaveVM<Teacher>
{
    private readonly IRepository<Teacher> _repository = RepositoryModule<Teacher>.GetRepository("Teachers");
    private readonly IValidationName validationName = new CheckTeacherData();
    private readonly IValidationPatronymic validationPatronymic = new CheckTeacherData();
    private readonly IValidationSurname validationSurname = new CheckTeacherData();
    public async Task<string> SaveAsync(Teacher obj)
    {
        StringBuilder errors = new();
        bool result = validationName.ValidateName(obj.Name);
        if (result == false) errors.AppendLine("Имя преподавателя введено неправильно");
        result = validationSurname.ValidateSurname(obj.Surname);
        if (result == false) errors.AppendLine("Фамилия преподавателя введено неправильно");
        result = validationPatronymic.ValidatePatronymic(obj.Patronymic);
        if (result == false) errors.AppendLine("Отчество преподавателя введено неправильно");
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
