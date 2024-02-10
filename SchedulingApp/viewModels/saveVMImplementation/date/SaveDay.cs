using Model.entities.date;
using Model.repositories;
using Model.validation.day;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation.date;

public class SaveDay(IDayOfWeekValidation dayOfWeekValidation) : ISaveVM<DayEntity>
{
    private readonly IRepository<DayEntity> _repository = RepositoryModule<DayEntity>.GetRepository("Days");
    private readonly IDayOfWeekValidation _dayValidation = dayOfWeekValidation;
    public async Task<string> SaveAsync(DayEntity obj)
    {
        StringBuilder errors = new();
        string result = _dayValidation.ValidateDayOfWeek(obj.DayOfWeek);
        if (result == "data is empty or incorrect") errors.AppendLine(result);
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
