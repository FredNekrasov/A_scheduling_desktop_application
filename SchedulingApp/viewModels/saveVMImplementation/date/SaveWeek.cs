using Model.entities.date;
using Model.repositories;
using Model.validation.weeks;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation.date;

public class SaveWeek(IWeekNumberValidation weekNumberValidation) : ISaveVM<Week>
{
    private readonly IRepository<Week> _repository = RepositoryModule<Week>.GetRepository("Weeks");
    private readonly IWeekNumberValidation _weekNumberValidation = weekNumberValidation;
    public async Task<string> SaveAsync(Week obj)
    {
        StringBuilder errors = new();
        bool result = _weekNumberValidation.ValidateWeekNumber(obj.WeekNumber);
        if (result == false) errors.AppendLine("Введен некорректный номер недели");
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
