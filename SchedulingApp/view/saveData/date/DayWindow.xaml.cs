using Model.entities.date;
using SchedulingApp.viewModels.basicVMImplementation.date;
using SchedulingApp.viewModels;
using System.Windows;
using Model.validation.day;
using SchedulingApp.viewModels.saveVMImplementation.date;
using Model.entities;
using SchedulingApp.viewModels.basicVMImplementation;

namespace SchedulingApp.view.saveData.date
{
    public partial class DayWindow : Window
    {
        private readonly ISaveVM<DayEntity> _saveVM;
        private readonly IBasicVM<Week> _weeksBasicVM = new WeekVM();
        private readonly IBasicVM<PairEntity> _pairsBasicVM = new PairVM();
        private DayEntity entity = new();
        public DayWindow(DayEntity? selectedItem)
        {
            InitializeComponent();
            IDayOfWeekValidation dayOfWeekValidation = new CheckDayData();
            _saveVM = new SaveDay(dayOfWeekValidation);
            SetData();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
        private async void SetData()
        {
            await _weeksBasicVM.LoadData();
            WeekCB.ItemsSource = _weeksBasicVM.List;
            await _pairsBasicVM.LoadData();
            PairsLV1.ItemsSource = _pairsBasicVM.List;
            PairsLV2.ItemsSource = _pairsBasicVM.List;
            PairsLV3.ItemsSource = _pairsBasicVM.List;
            PairsLV4.ItemsSource = _pairsBasicVM.List;
            PairsLV5.ItemsSource = _pairsBasicVM.List;
            PairsLV6.ItemsSource = _pairsBasicVM.List;
            PairsLV7.ItemsSource = _pairsBasicVM.List;
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
