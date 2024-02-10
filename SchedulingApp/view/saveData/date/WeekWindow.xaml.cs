using Model.entities.date;
using System.Windows;

namespace SchedulingApp.view.saveData.date
{
    public partial class WeekWindow : Window
    {
        private Week entity = new();
        public WeekWindow(Week? selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
    }
}
