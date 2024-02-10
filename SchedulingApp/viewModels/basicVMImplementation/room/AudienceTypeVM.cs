using Model.entities.room;
using Model.repositories;
using System.Collections.ObjectModel;

namespace SchedulingApp.viewModels.basicVMImplementation.room;

public class AudienceTypeVM(IRepository<AudienceType> repository) : IBasicVM<AudienceType>
{
    private readonly IRepository<AudienceType> _repository = repository;
    public ObservableCollection<AudienceType> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = new ObservableCollection<AudienceType>(list);
    }

    public async Task RemoveAsync(AudienceType obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (ObservableCollection<AudienceType>)List
            .Where(i => i.TypeName.StartsWith(searchValue) || i.Description.StartsWith(searchValue));
}
