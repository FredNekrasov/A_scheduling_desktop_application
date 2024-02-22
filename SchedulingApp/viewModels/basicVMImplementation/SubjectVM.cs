using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class SubjectVM : VMBase, IBasicVM<Subject>
{
    private readonly IRepository<Subject> _repository = RepositoryModule<Subject>.GetRepository("Subjects");
    private List<Subject> _list;
    public List<Subject> List
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
    public async Task RemoveAsync(Subject obj) => await _repository.Delete(obj.ID);
}