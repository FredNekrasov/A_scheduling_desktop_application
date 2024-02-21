﻿using Model.entities;
using SchedulingApp.viewModels;
using SchedulingApp.viewModels.saveVMImplementation;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class SquadWindow : Window
    {
        private readonly ISaveVM<Squad> _saveVM;
        private Squad entity = new();
        public SquadWindow(Squad? selectedItem)
        {
            InitializeComponent();
            _saveVM = new SaveGroup();
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
