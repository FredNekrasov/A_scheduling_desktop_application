using Model.entities.date;
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
            _saveVM = new SaveSemester();
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
