using Model.entities;
using Model.validation.users;
using SchedulingApp.viewModels.saveVMImplementation;
using SchedulingApp.viewModels;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class UserWindow : Window
    {
        private readonly ISaveVM<User> _saveVM;
        private User entity = new();
        public UserWindow(User? selectedItem)
        {
            InitializeComponent();
            IValidationUserName validationUserName = new CheckUserData();
            IValidationPassword validationPassword = new CheckUserData();
            IValidationEmail validationEmail = new CheckUserData();
            _saveVM = new SaveUser(validationUserName, validationPassword, validationEmail);
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            ViewListWindow viewList = new();
            Close();
            viewList.Show();
        }
        private async void SaveClick(object sender, RoutedEventArgs e)
        {
            var result = await _saveVM.SaveAsync(entity);
            if (result != "Ok")
            {
                MessageBox.Show(result, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Запись успешно создана", result, MessageBoxButton.OK, MessageBoxImage.Asterisk);
            GoBackClick(sender, e);
        }
    }
}
