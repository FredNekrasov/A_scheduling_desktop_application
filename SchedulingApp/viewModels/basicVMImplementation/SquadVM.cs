using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class SquadVM : IBasicVM<Squad>
{
    private readonly IRepository<Squad> _repository = RepositoryModule<Squad>.GetRepository("");
    public List<Squad> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }

    public async Task RemoveAsync(Squad obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (List<Squad>)List
        .Where(i =>
        i.GroupNumber.StartsWith(searchValue)
        || i.ShortNumber.StartsWith(searchValue)
        || i.StudentNumber.ToString().StartsWith(searchValue)
        );
}
