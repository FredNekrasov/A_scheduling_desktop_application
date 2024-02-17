using SchedulingApp.converter;
using SchedulingApp.mappers;

namespace SchedulingApp.viewModels;

interface IBasicVM<T>
{
    List<T> List { get; }
    Task LoadData();
    Task RemoveAsync(T obj);
    void GenerateExcelFile() => ExportToExcel.ToExcelFile(MapToDataTable.ToDataTable(List));
}
