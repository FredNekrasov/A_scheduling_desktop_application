using Model.entities;
using SchedulingApp.viewModels;
using SchedulingApp.viewModels.saveVMImplementation;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class PairWindow : Window
    {
        private readonly ISaveVM<PairEntity> _saveVM = new SavePair();
        private PairEntity entity = new();
        public PairWindow(PairEntity? selectedItem)
        {
            InitializeComponent();
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
