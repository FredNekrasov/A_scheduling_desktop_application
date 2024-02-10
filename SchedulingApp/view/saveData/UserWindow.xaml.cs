using Model.entities;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class UserWindow : Window
    {
        private User entity = new();
        public UserWindow(User? selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
    }
}
