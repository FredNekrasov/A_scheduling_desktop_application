using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class SquadVM : IBasicVM<Squad>
{
    private readonly IRepository<Squad> _repository = RepositoryModule<Squad>.GetRepository("Groups");
    public List<Squad> List { get; private set; }
    public async void LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }
    public async Task RemoveAsync(Squad obj) => await _repository.Delete(obj.ID);
}