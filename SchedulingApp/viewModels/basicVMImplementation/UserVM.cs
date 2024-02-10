﻿using Model.entities;
using Model.repositories;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class UserVM(IRepository<User> repository) : IBasicVM<User>
{
    private readonly IRepository<User> _repository = repository;
    public List<User> List { get; private set; }
    public async Task LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }

    public async Task RemoveAsync(User obj)
    {
        await _repository.Delete(obj.UserID);
        await LoadData();
    }

    public void Search(string searchValue) => List = (List<User>)List
        .Where(i =>
        i.UserName.StartsWith(searchValue) || i.Password.StartsWith(searchValue) || i.Email.StartsWith(searchValue)
        );
}
