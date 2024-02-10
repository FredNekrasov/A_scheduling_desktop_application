using Model.entities.room;
using System.Windows;

namespace SchedulingApp.view.saveData.room
{
    public partial class AudienceWindow : Window
    {
        private Audience entity = new();
        public AudienceWindow(Audience? selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
    }
}
