using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class SquadVM : VMBase, IBasicVM<Squad>
{
    private readonly IRepository<Squad> _repository = RepositoryModule<Squad>.GetRepository("Groups");
    private List<Squad> _list;
    public List<Squad> List
    {
        get => _list;
        private set
        {
            _list = value;
            OnPropertyChanged(nameof(List));
        }
    }
    public async void LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }
    public async Task RemoveAsync(Squad obj) => await _repository.Delete(obj.ID);
}