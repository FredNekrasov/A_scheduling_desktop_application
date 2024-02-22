﻿using Model.entities;
using Model.entities.room;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.room;

public class AudienceTypeVM : VMBase, IBasicVM<AudienceType>
{
    private readonly IRepository<AudienceType> _repository = RepositoryModule<AudienceType>.GetRepository("AudienceTypes");
    private List<AudienceType> _list;
    public List<AudienceType> List
    {
        get => _list;
        private set
        {
            _list = value;
            OnPropertyChanged(nameof(List));
        }
    }
    public async void LoadData()
    {
        var list = await _repository.Read();
        if (list == null) return;
        List = list.ToList();
    }
    public async Task RemoveAsync(AudienceType obj) => await _repository.Delete(obj.ID);
}