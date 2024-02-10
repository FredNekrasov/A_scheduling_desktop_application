using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class TeacherVM : IBasicVM<Teacher>
{
    private readonly IRepository<Teacher> _repository = RepositoryModule<Teacher>.GetRepository("Teachers");
    public List<Teacher> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }

    public async Task RemoveAsync(Teacher obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }
    public void Search(string searchValue) => List = (List<Teacher>)List
        .Where(i =>
        i.Patronymic.StartsWith(searchValue)
        || i.Surname.StartsWith(searchValue)
        || i.Name.StartsWith(searchValue)
        );
}
