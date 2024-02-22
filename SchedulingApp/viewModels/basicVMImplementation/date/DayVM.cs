using Model.entities;
using Model.entities.date;
using Model.entitiesForExcel;
using Model.repositories;
using SchedulingApp.converter;
using SchedulingApp.mappers;
using SchedulingApp.mappers.implementation;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.date;

public class DayVM : VMBase, IBasicVM<DayData>
{
    private readonly IRepository<DayEntity> _repository = RepositoryModule<DayEntity>.GetRepository("Days");
    private readonly IBasicVM<PairEntity> basicVM = new PairVM();
    private readonly IMapToXLSX<DayXLSX, DayData> mapToXLSX = new MapToDayXLSX();
    private List<DayData> _list;
    public List<DayData> List
    {
        get => _list;
        private set
        {
            _list = value;
            OnPropertyChanged(nameof(List));
        }
    }
    public void GenerateExcelFile() => ExportToExcel.ToExcelFile(MapToDataTable.ToDataTable(mapToXLSX.ToXLSXList(List)));
    public async void LoadData()
    {
        List<DayData> days = [];
        basicVM.LoadData();
        var list = await _repository.Read();
        if (list == null) return;
        foreach (var item in list)
        {
            DayData dayData = new()
            {
                ID = item.ID,
                DayOfWeek = item.DayOfWeek,
                Pair1 = basicVM.List.Find(i => i.PairID == item.Pair1),
                Pair2 = basicVM.List.Find(i => i.PairID == item.Pair2),
                Pair3 = basicVM.List.Find(i => i.PairID == item.Pair3),
                Pair4 = basicVM.List.Find(i => i.PairID == item.Pair4),
                Pair5 = basicVM.List.Find(i => i.PairID == item.Pair5),
                Pair6 = basicVM.List.Find(i => i.PairID == item.Pair6),
                Pair7 = basicVM.List.Find(i => i.PairID == item.Pair7),
                Week = item.Week
            };
            days.Add(dayData);
        }
        List = days;
    }
    public async Task RemoveAsync(DayData obj) => await _repository.Delete(obj.ID);
}
