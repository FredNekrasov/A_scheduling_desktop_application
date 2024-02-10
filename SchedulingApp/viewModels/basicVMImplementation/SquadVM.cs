using Model.entities;
using Model.repositories;
using System.Collections.ObjectModel;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class SquadVM(IRepository<Squad> repository) : IBasicVM<Squad>
{
    private readonly IRepository<Squad> _repository = repository;
    public ObservableCollection<Squad> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = new ObservableCollection<Squad>(list);
    }

    public async Task RemoveAsync(Squad obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (ObservableCollection<Squad>)List
        .Where(i =>
        i.GroupNumber.StartsWith(searchValue)
        || i.ShortNumber.StartsWith(searchValue)
        || i.StudentNumber.ToString().StartsWith(searchValue)
        );
}
