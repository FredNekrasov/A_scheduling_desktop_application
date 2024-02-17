using Model.entities.room;
using Model.entitiesForExcel;
using Model.repositories;
using SchedulingApp.converter;
using SchedulingApp.mappers;
using SchedulingApp.mappers.implementation;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.room;

public class AudienceVM : IBasicVM<Audience>
{
    private readonly IRepository<Audience> _repository = RepositoryModule<Audience>.GetRepository("Audiences");
    private readonly IMapToXLSX<AudienceXLSX, Audience> mapToXLSX = new MapToAudienceXLSX();
    public List<Audience> List { get; private set; }
    public void GenerateExcelFile() => ExportToExcel.ToExcelFile(MapToDataTable.ToDataTable(mapToXLSX.ToXLSXList(List)));
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }

    public async Task RemoveAsync(Audience obj) => await _repository.Delete(obj.ID);
    public void Search(string searchValue) => List = (List<Audience>)List
            .Where(i =>
            i.SeatsNumber.ToString().StartsWith(searchValue)
            || i.AudienceNumber.StartsWith(searchValue)
            || i.StudentNumber.ToString().StartsWith(searchValue)
            || i.AudienceType.TypeName.StartsWith(searchValue)
            );
}
