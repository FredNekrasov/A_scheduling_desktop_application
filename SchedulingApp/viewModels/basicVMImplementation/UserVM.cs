using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class UserVM : VMBase, IBasicVM<User>
{
    private readonly IRepository<User> _repository = RepositoryModule<User>.GetRepository("Users");
    private List<User> _list;
    public List<User> List
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
    public async Task RemoveAsync(User obj) => await _repository.Delete(obj.UserID);
}