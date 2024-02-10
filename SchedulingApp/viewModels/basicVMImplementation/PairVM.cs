using Model.entities;
using Model.repositories;
using System.Collections.ObjectModel;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class PairVM(IRepository<PairEntity> repository) : IBasicVM<PairEntity>
{
    private readonly IRepository<PairEntity> _repository = repository;
    public ObservableCollection<PairEntity> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = new ObservableCollection<PairEntity>(list);
    }

    public async Task RemoveAsync(PairEntity obj)
    {
        await _repository.Delete(obj.PairID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (ObservableCollection<PairEntity>)List
        .Where(i =>
        i.Subject.SubjectName.StartsWith(searchValue)
        || i.Teacher.Surname.StartsWith(searchValue)
        || i.Teacher.Name.StartsWith(searchValue)
        || i.Teacher.Patronymic.StartsWith(searchValue)
        || i.Group.ShortNumber.StartsWith(searchValue)
        || i.Audience.AudienceNumber.StartsWith(searchValue)
        );
}
