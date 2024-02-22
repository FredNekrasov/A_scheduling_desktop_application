using Model.entities.room;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.room;

public class AudienceTypeVM : IBasicVM<AudienceType>
{
    private readonly IRepository<AudienceType> _repository = RepositoryModule<AudienceType>.GetRepository("AudienceTypes");
    public List<AudienceType> List { get; set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }
    public async Task RemoveAsync(AudienceType obj) => await _repository.Delete(obj.ID);
}