using Model.entities;
using Model.repositories;

namespace SchedulingApp.viewModels.saveVMImplementation;

public class SavePair(IRepository<PairEntity> repository) : ISaveVM<PairEntity>
{
    private readonly IRepository<PairEntity> _repository = repository;
    public async Task<string> SaveAsync(PairEntity obj)
    {
        if (obj.PairID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.PairID);
        return "Ok";
    }
}
