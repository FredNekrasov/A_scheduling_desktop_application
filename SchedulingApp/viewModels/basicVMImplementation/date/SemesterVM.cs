using Model.entities.date;
using Model.repositories;
using System.Collections.ObjectModel;

namespace SchedulingApp.viewModels.basicVMImplementation.date;

public class SemesterVM(IRepository<Semester> repository) : IBasicVM<Semester>
{
    private readonly IRepository<Semester> _repository = repository;
    public ObservableCollection<Semester> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = new ObservableCollection<Semester>(list);
    }

    public async Task RemoveAsync(Semester obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (ObservableCollection<Semester>)List
            .Where(i => i.Year.ToString().StartsWith(searchValue) || i.IsEven.ToString().StartsWith(searchValue));
}
