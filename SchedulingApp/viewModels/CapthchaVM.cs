using Model.captcha;

namespace SchedulingApp.viewModels
{
    public class CapthchaVM
    {
        private readonly GenerateCaptcha generateCaptcha;
        private string password = string.Empty;
        private string font = string.Empty;
        public string Captcha { get => password; }
        public string Font { get => font; }
        public CapthchaVM(GenerateCaptcha _generateCaptcha)
        {
            generateCaptcha = _generateCaptcha;
            ReCreateCaptcha();
        }
        public void ReCreateCaptcha()
        {
            string[] result = generateCaptcha.GenerateCaptchaCode().Split(',');
            password = result[0];
            font = result[1];
        }
    }
}
