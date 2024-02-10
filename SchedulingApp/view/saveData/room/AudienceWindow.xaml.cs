using Model.entities.room;
using Model.validation.audiences;
using SchedulingApp.viewModels;
using SchedulingApp.viewModels.basicVMImplementation.room;
using SchedulingApp.viewModels.saveVMImplementation.room;
using System.Windows;

namespace SchedulingApp.view.saveData.room
{
    public partial class AudienceWindow : Window
    {
        private readonly ISaveVM<Audience> _saveVM;
        private readonly IBasicVM<AudienceType> basicVM = new AudienceTypeVM();
        private Audience entity = new();
        public AudienceWindow(Audience? selectedItem)
        {
            InitializeComponent();
            IAudienceNumberValidation audienceNumberValidation = new CheckAudienceData();
            ISeatsNumberValidation seatsNumberValidation = new CheckAudienceData();
            IStudentNumberValidation studentNumberValidation = new CheckAudienceData();
            AudiencesComboBox.ItemsSource = basicVM.List;
            _saveVM = new SaveAudience(audienceNumberValidation, seatsNumberValidation, studentNumberValidation);
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
