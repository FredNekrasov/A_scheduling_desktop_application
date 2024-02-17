using Model.entities;
using Model.validation.teachers;
using SchedulingApp.viewModels;
using SchedulingApp.viewModels.saveVMImplementation;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class TeacherWindow : Window
    {
        private readonly ISaveVM<Teacher> _saveVM;
        private Teacher entity = new();
        public TeacherWindow(Teacher? selectedItem)
        {
            InitializeComponent();
            IValidationName validationName = new CheckTeacherData();
            IValidationPatronymic validationPatronymic = new CheckTeacherData();
            IValidationSurname validationSurname = new CheckTeacherData();
            _saveVM = new SaveTeacher(validationName, validationPatronymic, validationSurname);
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
