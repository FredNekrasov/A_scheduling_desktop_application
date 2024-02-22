﻿using Model.entities;
using Model.repositories;
using Model.validation.groups;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation;

public class SaveGroup() : ISaveVM<Squad>
{
    private readonly IRepository<Squad> _repository = RepositoryModule<Squad>.GetRepository("Groups");
    private readonly IValidationGroupNumber validationGroupNumber = new CheckGroupData();
    private readonly IValidationShortGN validationShortGN = new CheckGroupData();
    private readonly IValidationStudentNumber validationStudentNumber = new CheckGroupData();
    public async Task<string> SaveAsync(Squad obj)
    {
        StringBuilder errors = new();
        bool result = validationGroupNumber.ValidateGroupNumber(obj.GroupNumber);
        if (result == false) errors.AppendLine("Полный номер группы введен неправильно");
        result = validationShortGN.ValidateShortGN(obj.ShortNumber);
        if (result == false) errors.AppendLine("Номер группы введен неправильно");
        result = validationStudentNumber.ValidateStudentNumber(obj.StudentNumber);
        if (result == false) errors.AppendLine("Введено неправильное количество студентов");
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
