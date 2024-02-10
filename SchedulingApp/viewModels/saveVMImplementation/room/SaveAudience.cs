﻿using Model.entities.room;
using Model.repositories;
using Model.validation.audiences;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation.room;

public class SaveAudience(
    IRepository<Audience> repository,
    IAudienceNumberValidation audienceNumberValidation,
    ISeatsNumberValidation seatsNumberValidation,
    IStudentNumberValidation studentNumberValidation
) : ISaveVM<Audience>
{
    private readonly IRepository<Audience> _repository = repository;
    private readonly IAudienceNumberValidation _audienceNumberValidation = audienceNumberValidation;
    private readonly ISeatsNumberValidation _seatsNumberValidation = seatsNumberValidation;
    private readonly IStudentNumberValidation _studentNumberValidation = studentNumberValidation;
    public async Task<string> SaveAsync(Audience obj)
    {
        StringBuilder errors = new();
        bool result = _audienceNumberValidation.ValidateAudienceNumber(obj.AudienceNumber);
        if (result == false) errors.AppendLine("Введен неправильный номер аудитории");
        result = _seatsNumberValidation.ValidateSeatsNumber(obj.SeatsNumber);
        if (result == false) errors.AppendLine("Введено неправильное количество мест в аудитории");
        result = _studentNumberValidation.ValidateStudentNumber(obj.StudentNumber);
        if (result == false) errors.AppendLine("Введено неправильное количество мест для студентов");
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
