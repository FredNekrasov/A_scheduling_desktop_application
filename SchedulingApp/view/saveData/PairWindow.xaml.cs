using Model.entities;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class PairWindow : Window
    {
        private PairEntity entity = new();
        public PairWindow(PairEntity? selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
    }
}
