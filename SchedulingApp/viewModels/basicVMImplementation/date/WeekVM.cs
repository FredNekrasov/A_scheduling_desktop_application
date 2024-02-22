using Model.entities;
using Model.entities.date;
using Model.entitiesForExcel;
using Model.repositories;
using SchedulingApp.converter;
using SchedulingApp.mappers;
using SchedulingApp.mappers.implementation;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.date;

public class WeekVM : VMBase, IBasicVM<Week>
{
    private readonly IRepository<Week> _repository = RepositoryModule<Week>.GetRepository("Weeks");
    private readonly IMapToXLSX<WeekXLSX, Week> mapToXLSX = new MapToWeekXLSX();
    private List<Week> _list;
    public List<Week> List
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
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }
    public async Task RemoveAsync(Week obj) => await _repository.Delete(obj.ID);
}