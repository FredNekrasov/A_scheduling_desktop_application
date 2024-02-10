using Model.repositories;
using Model.repositories.implementation;

namespace SchedulingApp.stupidDI;

public class RepositoryModule<T>
{
    private static IRepository<T>? repository;
    public static IRepository<T> GetRepository(string apiName)
    {
        repository ??= new Repository<T>(ServiceModule.GetAPI(), apiName);
        return repository;
    }
}
