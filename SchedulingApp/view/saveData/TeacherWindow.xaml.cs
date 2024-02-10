using Model.entities;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class TeacherWindow : Window
    {
        private Teacher entity = new();
        public TeacherWindow(Teacher? selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
    }
}
