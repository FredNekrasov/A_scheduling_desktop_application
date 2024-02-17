using Model.entities.date;
using Model.entities.room;
using Model.entities;
using SchedulingApp.viewModels.basicVMImplementation.date;
using SchedulingApp.viewModels.basicVMImplementation.room;
using SchedulingApp.viewModels.basicVMImplementation;
using SchedulingApp.viewModels;
using System.Windows;
using SchedulingApp.view.saveData.date;
using SchedulingApp.view.saveData.room;
using SchedulingApp.view.saveData;
using System.Windows.Controls;

namespace SchedulingApp.view;
public partial class ViewListWindow : Window
{
    private readonly IBasicVM<User> _userVM = new UserVM();
    private readonly IBasicVM<Teacher> _teacherVM = new TeacherVM();
    private readonly IBasicVM<Subject> _subjectVM = new SubjectVM();
    private readonly IBasicVM<Squad> _groupVM = new SquadVM();
    private readonly IBasicVM<AudienceType> _audienceTypeVM = new AudienceTypeVM();
    private readonly IBasicVM<Audience> _audienceVM = new AudienceVM();
    private readonly IBasicVM<Semester> _semesterVM = new SemesterVM();
    private readonly IBasicVM<Week> _weekVM = new WeekVM();
    private readonly IBasicVM<PairEntity> _pairVM = new PairVM();
    private readonly IBasicVM<DayData> _dayVM = new DayVM();
    public ViewListWindow()
    {
        InitializeComponent();
        SetList();
    }
    private void Go_back_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new();
        Close();
        mainWindow.Show();
    }
    private async void SetList()
    {
        await _userVM.LoadData();
        await _teacherVM.LoadData();
        await _subjectVM.LoadData();
        await _groupVM.LoadData();
        await _audienceTypeVM.LoadData();
        await _audienceVM.LoadData();
        await _semesterVM.LoadData();
        await _weekVM.LoadData();
        await _pairVM.LoadData();
        await _dayVM.LoadData();
        UsersDG.ItemsSource = _userVM.List;
        TeachersDG.ItemsSource = _teacherVM.List;
        SubjectsDG.ItemsSource = _subjectVM.List;
        AudienceTypesDG.ItemsSource = _audienceTypeVM.List;
        AudiencesDG.ItemsSource = _audienceVM.List;
        SemestersDG.ItemsSource = _semesterVM.List;
        WeeksDG.ItemsSource = _weekVM.List;
        GroupsDG.ItemsSource = _groupVM.List;
        PairsLV.ItemsSource = _pairVM.List;
        DaysLV.ItemsSource = _dayVM.List;
    }
    private async Task DeleteRecordAsync<T>(IBasicVM<T> vm, T? record)
    {
        if (record == null) return;
        await vm.RemoveAsync(record);
        SetList();
    }

    private void GenerateExcelFileUsers(object sender, RoutedEventArgs e) => _userVM.GenerateExcelFile();
    private void GenerateExcelFileTeachers(object sender, RoutedEventArgs e) => _teacherVM.GenerateExcelFile();
    private void GenerateExcelFileGroups(object sender, RoutedEventArgs e) => _groupVM.GenerateExcelFile();
    private void GenerateExcelFileSubjects(object sender, RoutedEventArgs e) => _subjectVM.GenerateExcelFile();
    private void GenerateExcelFileAudienceTypes(object sender, RoutedEventArgs e) => _audienceTypeVM.GenerateExcelFile();
    private void GenerateExcelFileAudiences(object sender, RoutedEventArgs e) => _audienceVM.GenerateExcelFile();
    private void GenerateExcelFileSemesters(object sender, RoutedEventArgs e) => _semesterVM.GenerateExcelFile();
    private void GenerateExcelFileWeek(object sender, RoutedEventArgs e) => _weekVM.GenerateExcelFile();
    private void GenerateExcelFilePair(object sender, RoutedEventArgs e) => _pairVM.GenerateExcelFile();
    private void GenerateExcelFileDay(object sender, RoutedEventArgs e) => _dayVM.GenerateExcelFile();

    private async void DeleteUser(object sender, RoutedEventArgs e) => await DeleteRecordAsync(_userVM, ((Button)sender).DataContext as User);
    private async void DeleteTeacher(object sender, RoutedEventArgs e) => await DeleteRecordAsync(_teacherVM, ((Button)sender).DataContext as Teacher);
    private async void DeleteGroup(object sender, RoutedEventArgs e) => await DeleteRecordAsync(_groupVM, ((Button)sender).DataContext as Squad);
    private async void DeleteSubject(object sender, RoutedEventArgs e) => await DeleteRecordAsync(_subjectVM, ((Button)sender).DataContext as Subject);
    private async void DeleteAudienceType(object sender, RoutedEventArgs e) => await DeleteRecordAsync(_audienceTypeVM, ((Button)sender).DataContext as AudienceType);
    private async void DeleteAudience(object sender, RoutedEventArgs e) => await DeleteRecordAsync(_audienceVM, ((Button)sender).DataContext as Audience);
    private async void DeleteSemester(object sender, RoutedEventArgs e) => await DeleteRecordAsync(_semesterVM, ((Button)sender).DataContext as Semester);
    private async void DeleteWeek(object sender, RoutedEventArgs e) => await DeleteRecordAsync(_weekVM, ((Button)sender).DataContext as Week);
    private async void DeletePair(object sender, RoutedEventArgs e) => await DeleteRecordAsync(_pairVM, ((Button)sender).DataContext as PairEntity);
    private async void DeleteDay(object sender, RoutedEventArgs e) => await DeleteRecordAsync(_dayVM, ((Button)sender).DataContext as DayData);

    private void OpenUserWindow(object sender, RoutedEventArgs e)
    {
        UserWindow userWindow = new(((Button)sender).DataContext as User);
        Close();
        userWindow.Show();
    }
    private void OpenTeacherWindow(object sender, RoutedEventArgs e)
    {
        TeacherWindow teacherWindow = new(((Button)sender).DataContext as Teacher);
        Close();
        teacherWindow.Show();
    }
    private void OpenGroupWindow(object sender, RoutedEventArgs e)
    {
        SquadWindow groupWindow = new(((Button)sender).DataContext as Squad);
        Close();
        groupWindow.Show();
    }
    private void OpenSubjectWindow(object sender, RoutedEventArgs e)
    {
        SubjectWindow subjectWindow = new(((Button)sender).DataContext as Subject);
        Close();
        subjectWindow.Show();
    }
    private void OpenAudienceTypeWindow(object sender, RoutedEventArgs e)
    {
        AudienceTypeWindow audienceTypeWindow = new(((Button)sender).DataContext as AudienceType);
        Close();
        audienceTypeWindow.Show();
    }
    private void OpenAudienceWindow(object sender, RoutedEventArgs e)
    {
        AudienceWindow audienceWindow = new(((Button)sender).DataContext as Audience);
        Close();
        audienceWindow.Show();
    }
    private void OpenSemesterWindow(object sender, RoutedEventArgs e)
    {
        SemesterWindow semesterWindow = new(((Button)sender).DataContext as Semester);
        Close();
        semesterWindow.Show();
    }
    private void OpenWeekWindow(object sender, RoutedEventArgs e)
    {
        WeekWindow weekWindow = new(((Button)sender).DataContext as Week);
        Close();
        weekWindow.Show();
    }
    private void OpenPairWindow(object sender, RoutedEventArgs e)
    {
        PairWindow pairWindow = new(((Button)sender).DataContext as PairEntity);
        Close();
        pairWindow.Show();
    }
    private void OpenDayWindow(object sender, RoutedEventArgs e)
    {
        DayWindow dayWindow = new();
        Close();
        dayWindow.Show();
    }
}
