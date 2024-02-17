using Model.entities;
using Model.validation.subjects;
using SchedulingApp.viewModels.saveVMImplementation;
using SchedulingApp.viewModels;
using System.Windows;

namespace SchedulingApp.view.saveData
{
    public partial class SubjectWindow : Window
    {
        private readonly ISaveVM<Subject> _saveVM;
        private Subject entity = new();
        public SubjectWindow(Subject? selectedItem)
        {
            InitializeComponent();
            ISubjectNameValidation subjectNameValidation = new CheckSubjectData();
            ILectureHoursValidation lectureHoursValidation = new CheckSubjectData();
            IPracticeHoursValidation practiceHoursValidation = new CheckSubjectData();
            IConsultationHoursValidation consultationHoursValidation = new CheckSubjectData();
            ITotalHoursValidation totalHoursValidation = new CheckSubjectData();
            ITypeOfCertificationValidation typeOfCertificationValidation = new CheckSubjectData();
            _saveVM = new SaveSubject(
                consultationHoursValidation,
                lectureHoursValidation,
                practiceHoursValidation,
                subjectNameValidation,
                totalHoursValidation,
                typeOfCertificationValidation
                );
            if (selectedItem != null) entity = selectedItem;
            DataContext = entity;
        }
        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            ViewListWindow viewList = new();
            Close();
            viewList.Show();
        }
        private async void SaveClick(object sender, RoutedEventArgs e)
        {
            var result = await _saveVM.SaveAsync(entity);
            if (result != "Ok")
            {
                MessageBox.Show(result, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Запись успешно создана", result, MessageBoxButton.OK, MessageBoxImage.Asterisk);
            GoBackClick(sender, e);
        }
    }
}
