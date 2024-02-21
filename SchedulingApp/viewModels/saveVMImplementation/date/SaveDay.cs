using Model.entities;
using Model.entities.date;
using Model.repositories;
using Model.validation.day;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation.date;

public class SaveDay : VMBase, ISaveVM<DayData>
{
    private readonly IRepository<DayEntity> _repository = RepositoryModule<DayEntity>.GetRepository("Days");
    private readonly IDayOfWeekValidation dayOfWeekValidation = new CheckDayData();
    public async Task<string> SaveAsync(DayData obj)
    {
        StringBuilder errors = new();
        var entity = GetEntity(obj);
        string result = dayOfWeekValidation.ValidateDayOfWeek(entity.DayOfWeek);
        if (result == "data is empty or incorrect") errors.AppendLine(result);
        if (entity.Week == null) errors.AppendLine("Номер недели не выбран");
        if (errors.Length > 0) return errors.ToString();
        if (entity.ID == 0) await _repository.Create(entity); else await _repository.Update(entity, entity.ID);
        return "Ok";
    }
    private static DayEntity GetEntity(DayData data)
    {
        return new DayEntity()
        {
            ID = data.ID,
            DayOfWeek = data.DayOfWeek,
            Pair1 = GetID(data.Pair1),
            Pair2 = GetID(data.Pair2),
            Pair3 = GetID(data.Pair3),
            Pair4 = GetID(data.Pair4),
            Pair5 = GetID(data.Pair5),
            Pair6 = GetID(data.Pair6),
            Pair7 = GetID(data.Pair7),
            Week = data.Week
        };
    }
    private static int? GetID(PairEntity? pairEntity) => pairEntity?.PairID;
}
