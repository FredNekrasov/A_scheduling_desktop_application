using Model.entities.room;
using Model.repositories;
using Model.validation.audienceTypes;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation.room;

public class SaveAudienceType(
    IRepository<AudienceType> repository,
    ITypeNameValidation typeNameValidation,
    IDescriptionValidation descriptionValidation
) : ISaveVM<AudienceType>
{
    private readonly IRepository<AudienceType> _repository = repository;
    private readonly ITypeNameValidation _typeNameValidation = typeNameValidation;
    private readonly IDescriptionValidation _descriptionValidation = descriptionValidation;
    public async Task<string> SaveAsync(AudienceType obj)
    {
        StringBuilder errors = new();
        bool result = _typeNameValidation.ValidateTypeName(obj.TypeName);
        if (result == false) errors.AppendLine("Введено некорректное назавние типа");
        result = _descriptionValidation.ValidateDescription(obj.Description);
        if (result == false) errors.AppendLine("Введено некорректное описание");
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
