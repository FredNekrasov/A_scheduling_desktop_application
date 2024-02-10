using Model.service;

namespace SchedulingApp.stupidDI;

public class ServiceModule
{
    private static ISchedulingAPI? api;
    public static ISchedulingAPI GetAPI()
    {
        api ??= new SchedulingAPI();
        return api;
    }
}
