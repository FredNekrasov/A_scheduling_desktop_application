using Model.entities.room;
using Model.validation.audienceTypes;
using SchedulingApp.viewModels.saveVMImplementation.room;
using SchedulingApp.viewModels;
using System.Windows;

namespace SchedulingApp.view.saveData.room
{
    public partial class AudienceTypeWindow : Window
    {
        private readonly ISaveVM<AudienceType> _saveVM;
        private AudienceType entity = new();
        public AudienceTypeWindow(AudienceType? selectedItem)
        {
            InitializeComponent();
            IDescriptionValidation descriptionValidation = new CheckAudienceTypeData();
            ITypeNameValidation typeNameValidation = new CheckAudienceTypeData();
            _saveVM = new SaveAudienceType(typeNameValidation, descriptionValidation);
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
