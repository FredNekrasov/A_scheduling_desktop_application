using Model.entities.room;
using Model.repositories;
using System.Collections.ObjectModel;

namespace SchedulingApp.viewModels.basicVMImplementation.room;

public class AudienceVM(IRepository<Audience> repository) : IBasicVM<Audience>
{
    private readonly IRepository<Audience> _repository = repository;
    public ObservableCollection<Audience> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = new ObservableCollection<Audience>(list);
    }

    public async Task RemoveAsync(Audience obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (ObservableCollection<Audience>)List
            .Where(i =>
            i.SeatsNumber.ToString().StartsWith(searchValue)
            || i.AudienceNumber.StartsWith(searchValue)
            || i.StudentNumber.ToString().StartsWith(searchValue)
            || i.AudienceType.TypeName.StartsWith(searchValue)
            );
}
