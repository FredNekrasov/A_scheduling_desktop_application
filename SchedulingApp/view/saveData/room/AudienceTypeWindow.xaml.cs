using Model.entities.room;
using System.Windows;

namespace SchedulingApp.view.saveData.room
{
    public partial class AudienceTypeWindow : Window
    {
        private AudienceType entity = new();
        public AudienceTypeWindow(AudienceType? selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
    }
}
