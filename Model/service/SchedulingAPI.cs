using System.Net.Http.Headers;

namespace Model.service;

public class SchedulingAPI : ISchedulingAPI
{
    private static HttpClient? api;
    private static HttpClient GetClient() => api ??= new HttpClient();
    public HttpClient GetHttp()
    {
        GetClient().BaseAddress = new Uri("https://localhost:7026/api/");
        GetClient().DefaultRequestHeaders.Accept.Clear();
        GetClient().DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return GetClient();
    }
}
