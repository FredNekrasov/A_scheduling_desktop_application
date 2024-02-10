using Model.entities;
using Model.repositories;
using System.Collections.ObjectModel;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class UserVM(IRepository<User> repository) : IBasicVM<User>
{
    private readonly IRepository<User> _repository = repository;
    public ObservableCollection<User> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = new ObservableCollection<User>(list);
    }

    public async Task RemoveAsync(User obj)
    {
        await _repository.Delete(obj.UserID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (ObservableCollection<User>)List
        .Where(i =>
        i.UserName.StartsWith(searchValue) || i.Password.StartsWith(searchValue) || i.Email.StartsWith(searchValue)
        );
}
