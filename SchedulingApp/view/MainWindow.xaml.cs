using SchedulingApp.stupidDI;
using SchedulingApp.viewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SchedulingApp.view;

public partial class MainWindow : Window
{
    private readonly FontFamilyConverter converter = new();
    private readonly CapthchaVM capthchaVM = new(CaptchaModule.GetGenerateCaptcha());
    public MainWindow()
    {
        InitializeComponent();
        SetData();
    }
    private void SetData()
    {
        password.Content = capthchaVM.Captcha;
        password.FontFamily = converter.ConvertFrom(capthchaVM.Font) as FontFamily;
        image.Visibility = Visibility.Visible;
    }
    private void Focus(object sender, RoutedEventArgs e)
    {
        TextBox tb = (TextBox)sender;
        if (tb.Text == "Введите данные из картинки") tb.Text = string.Empty;
        else if (Condition(tb.Text)) tb.Text = "Введите данные из картинки";
    }
    private static bool Condition(string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);

    private void CheckData(object sender, RoutedEventArgs e)
    {
        if (Condition(result.Text))
        {
            MessageBox.Show("Поле пустое", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        if (result.Text != capthchaVM.Captcha)
        {
            MessageBox.Show("Данные неправильные", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            ReCreateCaptcha();
            return;
        }
        MessageBox.Show("Это правильно! Вы успешно прошли", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        ViewListWindow viewList = new();
        Close();
        viewList.Show();
    }
    private void ChangeData(object sender, RoutedEventArgs e) => ReCreateCaptcha();
    private void ReCreateCaptcha()
    {
        capthchaVM.ReCreateCaptcha();
        SetData();
    }
}