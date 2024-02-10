using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.saveVMImplementation;

public class SavePair : ISaveVM<PairEntity>
{
    private readonly IRepository<PairEntity> _repository = RepositoryModule<PairEntity>.GetRepository("Pairs");
    public async Task<string> SaveAsync(PairEntity obj)
    {
        if (obj.PairID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.PairID);
        return "Ok";
    }
}
