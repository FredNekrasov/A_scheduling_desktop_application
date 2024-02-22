using Model.captcha;

namespace SchedulingApp.stupidDI;

public class CaptchaModule
{
    private static GenerateCaptcha? generateCaptcha;
    public static GenerateCaptcha GetGenerateCaptcha() => generateCaptcha ??= new();
}
