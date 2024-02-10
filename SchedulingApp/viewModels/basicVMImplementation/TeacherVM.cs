﻿using Model.entities;
using Model.repositories;
using System.Collections.ObjectModel;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class TeacherVM(IRepository<Teacher> repository) : IBasicVM<Teacher>
{
    private readonly IRepository<Teacher> _repository = repository;
    public ObservableCollection<Teacher> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = new ObservableCollection<Teacher>(list);
    }

    public async Task RemoveAsync(Teacher obj)
    {
        await _repository.Delete(obj.ID);
        await LoadData();
    }
    public void Search(string searchValue) => List = (ObservableCollection<Teacher>)List
        .Where(i =>
        i.Patronymic.StartsWith(searchValue)
        || i.Surname.StartsWith(searchValue)
        || i.Name.StartsWith(searchValue)
        );
}
