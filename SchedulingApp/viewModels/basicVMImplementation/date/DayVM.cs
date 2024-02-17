using Model.entities;
using Model.entities.date;
using Model.entitiesForExcel;
using Model.repositories;
using SchedulingApp.stupidDI;

namespace SchedulingApp.viewModels.basicVMImplementation.date;

public class DayVM : IBasicVM<DayData>
{
    private readonly IRepository<DayEntity> _repository = RepositoryModule<DayEntity>.GetRepository("Days");
    private readonly IBasicVM<PairEntity> basicVM = new PairVM();
    public List<DayData> List { get; private set; }
    public async Task LoadData()
    {
        /* old version
         PairEntity pairEntity = new()
        {
            Subject = new Subject { SubjectName = "qwerty" },
            Audience = new Audience { AudienceNumber = "494" },
            Teacher = new Teacher { Name = "сегодня", Surname = "уроков", Patronymic = "не будет" },
            Group = new Squad { ShortNumber = "qwerty-494" }
        };
        List<DayData> dayList = [];
        await basicVM.LoadData();
        var list = await _repository.Read();
        if (list == null) return;
        foreach (var item in list)
        {
            DayData dayData = new()
            {
                ID = item.ID,
                DayOfWeek = item.DayOfWeek,
                Pair1 = basicVM.List.Find(i => i.PairID == item.Pair1),
                Pair2 = basicVM.List.Find(i => i.PairID == item.Pair2),
                Pair3 = item.Pair3 == null ? pairEntity : basicVM.List.Find(i => i.PairID == item.Pair3),
                Pair4 = item.Pair4 == null ? pairEntity : basicVM.List.Find(i => i.PairID == item.Pair4),
                Pair5 = item.Pair5 == null ? pairEntity : basicVM.List.Find(i => i.PairID == item.Pair5),
                Pair6 = item.Pair6 == null ? pairEntity : basicVM.List.Find(i => i.PairID == item.Pair6),
                Pair7 = item.Pair7 == null ? pairEntity : basicVM.List.Find(i => i.PairID == item.Pair7),
                Week = item.Week
            };
            dayList.Add(dayData);
        }
        List = dayList;
         */
        List<DayData> days = [];
        await basicVM.LoadData();
        var list = await _repository.Read();
        if (list == null) return;
        foreach (var item in list)
        {

            DayData dayData = new()
            {
                ID = item.ID,
                DayOfWeek = item.DayOfWeek,
                Pair1 = basicVM.List.Find(i => i.PairID == item.Pair1),
                Pair2 = basicVM.List.Find(i => i.PairID == item.Pair2),
                Pair3 = basicVM.List.Find(i => i.PairID == item.Pair3),
                Pair4 = basicVM.List.Find(i => i.PairID == item.Pair4),
                Pair5 = basicVM.List.Find(i => i.PairID == item.Pair5),
                Pair6 = basicVM.List.Find(i => i.PairID == item.Pair6),
                Pair7 = basicVM.List.Find(i => i.PairID == item.Pair7),
                Week = item.Week
            };
            days.Add(dayData);
        }
        List = days;
    }

    public async Task RemoveAsync(DayData obj) => await _repository.Delete(obj.ID);
    public void Search(string searchValue) => List = (List<DayData>)List
           .Where(i =>
           i.DayOfWeek.StartsWith(searchValue) || i.Week.WeekNumber.ToString().StartsWith(searchValue));
}
