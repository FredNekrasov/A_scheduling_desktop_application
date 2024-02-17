namespace SchedulingApp.viewModels;

interface IBasicVM<T>
{
    List<T> List { get; }
    Task LoadData();
    Task RemoveAsync(T obj);
}
