using Model.entities.date;
using SchedulingApp.viewModels.basicVMImplementation.date;
using SchedulingApp.viewModels;
using System.Windows;
using Model.validation.day;
using SchedulingApp.viewModels.saveVMImplementation.date;
using Model.entities;
using SchedulingApp.viewModels.basicVMImplementation;
using Model.entitiesForExcel;

namespace SchedulingApp.view.saveData.date
{
    public partial class DayWindow : Window
    {
        private readonly ISaveVM<DayEntity> _saveVM;
        private readonly IBasicVM<Week> _weeksBasicVM = new WeekVM();
        private readonly IBasicVM<PairEntity> _pairsBasicVM = new PairVM();
        private DayData entity = new();
        public DayWindow()
        {
            InitializeComponent();
            IDayOfWeekValidation dayOfWeekValidation = new CheckDayData();
            _saveVM = new SaveDay(dayOfWeekValidation);
            SetData();
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
        private async Task<string> Save(DayEntity item) => await _saveVM.SaveAsync(item);
        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            ViewListWindow viewList = new();
            Close();
            viewList.Show();
        }
        private async void SaveClick(object sender, RoutedEventArgs e)
        {
            var result = await Save(GetEntity());
            if (result != "Ok")
            {
                MessageBox.Show(result, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Запись успешно создана", result, MessageBoxButton.OK, MessageBoxImage.Asterisk);
            GoBackClick(sender, e);
        }
        private DayEntity GetEntity()
        {
            DayEntity dayEntity = new()
            {
                ID = entity.ID,
                DayOfWeek = entity.DayOfWeek,
                Pair1 = GetID(entity.Pair1),
                Pair2 = GetID(entity.Pair2),
                Pair3 = GetID(entity.Pair3),
                Pair4 = GetID(entity.Pair4),
                Pair5 = GetID(entity.Pair5),
                Pair6 = GetID(entity.Pair6),
                Pair7 = GetID(entity.Pair7),
                Week = entity.Week
            };
            return dayEntity;
        }
        private static int? GetID(PairEntity? pairEntity)
        {
            if (pairEntity == null) return null; else return pairEntity.PairID;
        }
    }
}
