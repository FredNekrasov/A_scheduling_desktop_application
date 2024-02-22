using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class TeacherVM : VMBase, IBasicVM<Teacher>
{
    private readonly IRepository<Teacher> _repository = RepositoryModule<Teacher>.GetRepository("Teachers");
    private List<Teacher> _list;
    public List<Teacher> List
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
    public async Task RemoveAsync(Teacher obj) => await _repository.Delete(obj.ID);
}