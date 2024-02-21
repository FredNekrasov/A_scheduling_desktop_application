using Model.entities.date;
using Model.repositories;
using Model.validation.semesters;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation.date;

public class SaveSemester() : VMBase, ISaveVM<Semester>
{
    private readonly IRepository<Semester> _repository = RepositoryModule<Semester>.GetRepository("Semesters");
    private readonly IIsEvenValidation isEvenValidation = new CheckSemesterData();
    private readonly IYearValidation yearValidation = new CheckSemesterData();
    public async Task<string> SaveAsync(Semester obj)
    {
        StringBuilder errors = new();
        bool result = isEvenValidation.IsEvenValidation(obj.IsEven);
        if (result == false) errors.AppendLine("Введен неправильный номер семестра");
        result = yearValidation.ValidateYear(obj.Year);
        if (result == false) errors.AppendLine("Введен некорректный год семестра");
        if (errors.Length > 0) return errors.ToString();
        if (obj.ID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.ID);
        return "Ok";
    }
}
