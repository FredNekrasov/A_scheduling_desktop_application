using Model.entities.date;
using SchedulingApp.viewModels;
using SchedulingApp.viewModels.basicVMImplementation.date;
using SchedulingApp.viewModels.saveVMImplementation.date;
using System.Windows;

namespace SchedulingApp.view.saveData.date
{
    public partial class WeekWindow : Window
    {
        private readonly ISaveVM<Week> _saveVM;
        private readonly IBasicVM<Semester> _semestersBasicVM = new SemesterVM();
        private Week entity = new();
        public WeekWindow(Week? selectedItem)
        {
            InitializeComponent();
            SetData();
            _saveVM = new SaveWeek();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
        private void SetData()
        {
            _semestersBasicVM.LoadData();
            Semester.ItemsSource = _semestersBasicVM.List;
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
