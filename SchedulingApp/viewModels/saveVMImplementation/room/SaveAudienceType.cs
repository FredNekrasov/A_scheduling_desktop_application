using Model.entities.room;
using Model.repositories;
using Model.validation.audienceTypes;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation.room;

public class SaveAudienceType() : ISaveVM<AudienceType>
{
    private readonly IRepository<AudienceType> _repository = RepositoryModule<AudienceType>.GetRepository("AudienceTypes");
    private readonly IDescriptionValidation descriptionValidation = new CheckAudienceTypeData();
    private readonly ITypeNameValidation typeNameValidation = new CheckAudienceTypeData();
    public async Task<string> SaveAsync(AudienceType obj)
    {
        StringBuilder errors = new();
        bool result = typeNameValidation.ValidateTypeName(obj.TypeName);
        if (result == false) errors.AppendLine("Введено некорректное назавние типа");
        result = descriptionValidation.ValidateDescription(obj.Description);
        if (result == false) errors.AppendLine("Введено некорректное описание");
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
