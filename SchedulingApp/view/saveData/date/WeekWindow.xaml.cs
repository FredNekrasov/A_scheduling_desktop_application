using Model.entities.date;
using Model.validation.weeks;
using SchedulingApp.viewModels;
using SchedulingApp.viewModels.basicVMImplementation.date;
using SchedulingApp.viewModels.saveVMImplementation.date;
using System.Windows;

namespace SchedulingApp.view.saveData.date
{
    public partial class WeekWindow : Window
    {
        private readonly ISaveVM<Week> _saveVM;
        private readonly IBasicVM<Semester> basicVM = new SemesterVM();
        private Week entity = new();
        public WeekWindow(Week? selectedItem)
        {
            InitializeComponent();
            IWeekNumberValidation weekNumberValidation = new CheckWeekData();
            Semester.ItemsSource = basicVM.List;
            _saveVM = new SaveWeek(weekNumberValidation);
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
