using Model.entities.room;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.room;

public class AudienceTypeVM : IBasicVM<AudienceType>
{
    private readonly IRepository<AudienceType> _repository = RepositoryModule<AudienceType>.GetRepository("");
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
