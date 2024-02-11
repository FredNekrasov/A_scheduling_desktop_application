using Model.entities;
using Model.entities.room;
using SchedulingApp.viewModels;
using SchedulingApp.viewModels.basicVMImplementation;
using SchedulingApp.viewModels.basicVMImplementation.room;
using SchedulingApp.viewModels.saveVMImplementation;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class PairWindow : Window
    {
        private readonly ISaveVM<PairEntity> _saveVM = new SavePair();
        private readonly IBasicVM<Subject> _subjectsBasicVM = new SubjectVM();
        private readonly IBasicVM<Teacher> _teachersBasicVM = new TeacherVM();
        private readonly IBasicVM<Squad> _squadsBasicVM = new SquadVM();
        private readonly IBasicVM<Audience> _audienceBasicVM = new AudienceVM();
        private PairEntity entity = new();
        public PairWindow(PairEntity? selectedItem)
        {
            InitializeComponent();
            SetData();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
        private async void SetData()
        {
            await _subjectsBasicVM.LoadData();
            await _teachersBasicVM.LoadData();
            await _squadsBasicVM.LoadData();
            await _audienceBasicVM.LoadData();
            SubjectCB.ItemsSource = _subjectsBasicVM.List;
            TeacherCB.ItemsSource = _teachersBasicVM.List;
            GroupCB.ItemsSource = _squadsBasicVM.List;
            AudienceCB.ItemsSource = _audienceBasicVM.List;
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
