﻿using Model.entities;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation;

public class UserVM : IBasicVM<User>
{
    private readonly IRepository<User> _repository = RepositoryModule<User>.GetRepository("Users");
    public List<User> List { get; private set; }
    public async void LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }
    public async Task RemoveAsync(User obj) => await _repository.Delete(obj.UserID);
}