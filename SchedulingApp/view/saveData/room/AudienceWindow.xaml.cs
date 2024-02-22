using Model.entities.room;
using SchedulingApp.viewModels;
using SchedulingApp.viewModels.basicVMImplementation.room;
using SchedulingApp.viewModels.saveVMImplementation.room;
using System.Windows;

namespace SchedulingApp.view.saveData.room
{
    public partial class AudienceWindow : Window
    {
        private readonly ISaveVM<Audience> _saveVM;
        private readonly IBasicVM<AudienceType> _audienceTypesBasicVM = new AudienceTypeVM();
        private Audience entity = new();
        public AudienceWindow(Audience? selectedItem)
        {
            InitializeComponent();
            SetData();
            _saveVM = new SaveAudience();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
        private void SetData()
        {
            _audienceTypesBasicVM.LoadData();
            AudiencesComboBox.ItemsSource = _audienceTypesBasicVM.List;
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
