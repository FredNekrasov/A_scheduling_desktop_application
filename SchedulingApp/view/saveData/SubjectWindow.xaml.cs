using Model.entities;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class SubjectWindow : Window
    {
        private Subject entity = new();
        public SubjectWindow(Subject? selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
    }
}
