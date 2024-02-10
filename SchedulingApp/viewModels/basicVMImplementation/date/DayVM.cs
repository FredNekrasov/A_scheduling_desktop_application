using Model.entities.date;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.date;

public class DayVM : IBasicVM<DayEntity>
{
    private readonly IRepository<DayEntity> _repository = RepositoryModule<DayEntity>.GetRepository("");
    public List<DayEntity> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }

    public async Task RemoveAsync(DayEntity obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (List<DayEntity>)List
           .Where(i =>
           i.DayOfWeek.StartsWith(searchValue) || i.Week.WeekNumber.ToString().StartsWith(searchValue));
}
