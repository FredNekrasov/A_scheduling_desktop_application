namespace SchedulingApp.viewModels;

public interface ISaveVM<T>
{
    Task<string> SaveAsync(T obj);
}
