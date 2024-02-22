using Model.entities;
using Model.entities.date;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.date;

public class SemesterVM : VMBase, IBasicVM<Semester>
{
    private readonly IRepository<Semester> _repository = RepositoryModule<Semester>.GetRepository("Semesters");
    private List<Semester> _list;
    public List<Semester> List
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
    public async Task RemoveAsync(Semester obj) => await _repository.Delete(obj.ID);
}
