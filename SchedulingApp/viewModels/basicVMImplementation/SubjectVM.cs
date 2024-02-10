using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class SubjectVM : IBasicVM<Subject>
{
    private readonly IRepository<Subject> _repository = RepositoryModule<Subject>.GetRepository("Subjects");
    public List<Subject> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }

    public async Task RemoveAsync(Subject obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (List<Subject>)List
            .Where(i =>
            i.SubjectName == searchValue
            || i.LectureHours.ToString().StartsWith(searchValue)
            || i.PracticHours.ToString().StartsWith(searchValue)
            || i.ConsultationHours.ToString().StartsWith(searchValue)
            || i.TypeOfCertification.StartsWith(searchValue)
            || i.TotalHours.ToString().StartsWith(searchValue)
            );
}
