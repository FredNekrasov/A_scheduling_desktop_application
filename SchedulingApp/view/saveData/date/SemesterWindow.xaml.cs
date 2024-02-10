using Model.entities.date;
using System.Windows;

namespace SchedulingApp.view.saveData.date
{
    public partial class SemesterWindow : Window
    {
        private Semester entity = new();
        public SemesterWindow(Semester? selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
    }
}
