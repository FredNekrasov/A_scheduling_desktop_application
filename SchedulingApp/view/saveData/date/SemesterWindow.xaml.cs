using Model.entities.date;
using Model.validation.semesters;
using SchedulingApp.viewModels;
using SchedulingApp.viewModels.saveVMImplementation.date;
using System.Windows;

namespace SchedulingApp.view.saveData.date
{
    public partial class SemesterWindow : Window
    {
        private readonly ISaveVM<Semester> _saveVM;
        private Semester entity = new();
        public SemesterWindow(Semester? selectedItem)
        {
            InitializeComponent();
            IIsEvenValidation isEvenValidation = new CheckSemesterData();
            IYearValidation yearValidation = new CheckSemesterData();
            _saveVM = new SaveSemester(isEvenValidation, yearValidation);
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
        private async Task<string> Save() => await _saveVM.SaveAsync(entity);
        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            ViewListWindow viewList = new();
            Close();
            viewList.Show();
        }
        private async void SaveClick(object sender, RoutedEventArgs e)
        {
            var result = await Save();
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
