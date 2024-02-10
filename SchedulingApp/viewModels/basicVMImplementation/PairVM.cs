using Model.entities;
using Model.repositories;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class PairVM(IRepository<PairEntity> repository) : IBasicVM<PairEntity>
{
    private readonly IRepository<PairEntity> _repository = repository;
    public List<PairEntity> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }

    public async Task RemoveAsync(PairEntity obj)
    {
        await _repository.Delete(obj.PairID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (List<PairEntity>)List
        .Where(i =>
        i.Subject.SubjectName.StartsWith(searchValue)
        || i.Teacher.Surname.StartsWith(searchValue)
        || i.Teacher.Name.StartsWith(searchValue)
        || i.Teacher.Patronymic.StartsWith(searchValue)
        || i.Group.ShortNumber.StartsWith(searchValue)
        || i.Audience.AudienceNumber.StartsWith(searchValue)
        );
}
