using Model.entities;
using Model.repositories;
using Model.validation.teachers;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation;

public class SaveTeacher(
    IRepository<Teacher> repository,
    IValidationName validationName,
    IValidationPatronymic validationPatronymic,
    IValidationSurname validationSurname
) : ISaveVM<Teacher>
{
    private readonly IRepository<Teacher> _repository = repository;
    private readonly IValidationName _validationName = validationName;
    private readonly IValidationPatronymic _validationPatronymic = validationPatronymic;
    private readonly IValidationSurname _validationSurname = validationSurname;
    public async Task<string> SaveAsync(Teacher obj)
    {
        StringBuilder errors = new();
        bool result = _validationName.ValidateName(obj.Name);
        if (result == false) errors.AppendLine("Имя преподавателя введено неправильно");
        result = _validationSurname.ValidateSurname(obj.Surname);
        if (result == false) errors.AppendLine("Фамилия преподавателя введено неправильно");
        result = _validationPatronymic.ValidatePatronymic(obj.Patronymic);
        if (result == false) errors.AppendLine("Отчество преподавателя введено неправильно");
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
