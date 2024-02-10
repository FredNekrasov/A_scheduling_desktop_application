using Model.entities.date;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.date;

public class WeekVM : IBasicVM<Week>
{
    private readonly IRepository<Week> _repository = RepositoryModule<Week>.GetRepository("");
    public List<Week> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }

    public async Task RemoveAsync(Week obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (List<Week>)List
            .Where(i =>
            i.WeekNumber.ToString().StartsWith(searchValue)
            || i.Semester.Year.ToString().StartsWith(searchValue)
            || i.Semester.IsEven.ToString().StartsWith(searchValue)
            );
}
