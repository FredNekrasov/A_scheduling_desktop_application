﻿using Model.entities.date;
using Model.repositories;
using System.Collections.ObjectModel;

namespace SchedulingApp.viewModels.basicVMImplementation.date;

public class WeekVM(IRepository<Week> repository) : IBasicVM<Week>
{
    private readonly IRepository<Week> _repository = repository;
    public ObservableCollection<Week> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = new ObservableCollection<Week>(list);
    }

    public async Task RemoveAsync(Week obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (ObservableCollection<Week>)List
            .Where(i =>
            i.WeekNumber.ToString().StartsWith(searchValue)
            || i.Semester.Year.ToString().StartsWith(searchValue)
            || i.Semester.IsEven.ToString().StartsWith(searchValue)
            );
}
