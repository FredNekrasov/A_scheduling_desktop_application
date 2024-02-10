using Model.entities;
using Model.repositories;
using System.Collections.ObjectModel;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class SubjectVM(IRepository<Subject> repository) : IBasicVM<Subject>
{
    private readonly IRepository<Subject> _repository = repository;
    public ObservableCollection<Subject> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = new ObservableCollection<Subject>(list);
    }

    public async Task RemoveAsync(Subject obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (ObservableCollection<Subject>)List
            .Where(i =>
            i.SubjectName == searchValue
            || i.LectureHours.ToString().StartsWith(searchValue)
            || i.PracticHours.ToString().StartsWith(searchValue)
            || i.ConsultationHours.ToString().StartsWith(searchValue)
            || i.TypeOfCertification.StartsWith(searchValue)
            || i.TotalHours.ToString().StartsWith(searchValue)
            );
}
