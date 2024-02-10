using Model.entities.date;
using System.Windows;

namespace SchedulingApp.view.saveData.date
{
    public partial class DayWindow : Window
    {
        private DayEntity entity = new();
        public DayWindow(DayEntity? selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
    }
}
