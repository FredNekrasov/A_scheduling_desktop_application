using Model.entities.room;
using Model.repositories;

namespace SchedulingApp.viewModels.basicVMImplementation.room;

public class AudienceTypeVM(IRepository<AudienceType> repository) : IBasicVM<AudienceType>
{
    private readonly IRepository<AudienceType> _repository = repository;
    public List<AudienceType> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }

    public async Task RemoveAsync(AudienceType obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (List<AudienceType>)List
            .Where(i => i.TypeName.StartsWith(searchValue) || i.Description.StartsWith(searchValue));
}
