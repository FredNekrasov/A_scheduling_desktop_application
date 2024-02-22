using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation;

public class SavePair : ISaveVM<PairEntity>
{
    private readonly IRepository<PairEntity> _repository = RepositoryModule<PairEntity>.GetRepository("Pairs");
    public async Task<string> SaveAsync(PairEntity obj)
    {
        StringBuilder errors = new();
        if (obj.Subject == null) errors.AppendLine("Предмет не выбран");
        if (obj.Teacher == null) errors.AppendLine("Преподаватель не выбран");
        if (obj.Audience == null) errors.AppendLine("Аудитория не выбрана");
        if (obj.Group == null) errors.AppendLine("Группа не выбрана");
        if (obj.PairID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.PairID);
        return "Ok";
    }
}
