using Model.entities;
using Model.entitiesForExcel;
using Model.repositories;
using SchedulingApp.converter;
using SchedulingApp.mappers;
using SchedulingApp.mappers.implementation;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class PairVM : VMBase, IBasicVM<PairEntity>
{
    private readonly IRepository<PairEntity> _repository = RepositoryModule<PairEntity>.GetRepository("Pairs");
    private readonly IMapToXLSX<PairXLSX, PairEntity> mapToXLSX = new MapToPairXLSX();
    private List<PairEntity> _list;
    public List<PairEntity> List
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
    public void GenerateExcelFile() => ExportToExcel.ToExcelFile(MapToDataTable.ToDataTable(mapToXLSX.ToXLSXList(List)));
    public async Task RemoveAsync(PairEntity obj) => await _repository.Delete(obj.PairID);
}