using Model.entities;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class SquadWindow : Window
    {
        private Squad entity = new();
        public SquadWindow(Squad? selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
    }
}
