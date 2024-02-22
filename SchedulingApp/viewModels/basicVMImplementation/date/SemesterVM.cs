using Model.entities.date;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.date;

public class SemesterVM : IBasicVM<Semester>
{
    private readonly IRepository<Semester> _repository = RepositoryModule<Semester>.GetRepository("Semesters");
    public List<Semester> List { get; private set; }
    public async void LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }
    public async Task RemoveAsync(Semester obj) => await _repository.Delete(obj.ID);
}
