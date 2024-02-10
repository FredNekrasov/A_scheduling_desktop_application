using Model.service;
using Newtonsoft.Json;

namespace Model.repositories.implementation;

public class Repository<T>(ISchedulingAPI schedulingAPI, string apiName) : IRepository<T>
{
    private readonly HttpClient api = schedulingAPI.GetHttp();
    private readonly string endpoint = apiName + "/";
    public async Task Create(T entity) => await api.PostAsJsonAsync(apiName, entity);
    public async Task Delete(int id) => await api.DeleteAsync(endpoint + id);
    public async Task<IEnumerable<T>?> Read()
    {
        var response = await api.GetStringAsync(apiName);
        var items = JsonConvert.DeserializeObject<IEnumerable<T>>(response);
        if (items == null) return null;
        return items;
    }
    public async Task Update(T entity, int id) => await api.PutAsJsonAsync(endpoint + id, entity);
}
