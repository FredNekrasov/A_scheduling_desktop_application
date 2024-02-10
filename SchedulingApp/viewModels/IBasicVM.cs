using System.Collections.ObjectModel;

namespace SchedulingApp.viewModels
{
    interface IBasicVM<T>
    {
        ObservableCollection<T> List { get; }
        Task LoadData();
        Task RemoveAsync(T obj);
        void Search(string searchValue);
    }
}
