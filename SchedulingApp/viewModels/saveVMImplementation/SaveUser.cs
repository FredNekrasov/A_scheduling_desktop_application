using Model.entities;
using Model.repositories;
using Model.validation.users;
using SchedulingApp.stupidDI;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation;

public class SaveUser() : VMBase, ISaveVM<User>
{
    private readonly IRepository<User> _repository = RepositoryModule<User>.GetRepository("Users");
    private readonly IValidationUserName validationUserName = new CheckUserData();
    private readonly IValidationPassword validationPassword = new CheckUserData();
    private readonly IValidationEmail validationEmail = new CheckUserData();
    public async Task<string> SaveAsync(User obj)
    {
        StringBuilder errors = new();
        bool result = validationUserName.ValidateUserName(obj.UserName);
        if (result == false) errors.AppendLine("Имя пользователя введено неправильно");
        result = validationPassword.ValidatePassword(obj.Password);
        if (result == false) errors.AppendLine("Пароль введен неправильно. Длина пароля должна быть в 8 и более символов");
        result = validationEmail.ValidateEmail(obj.Email);
        if (result == false) errors.AppendLine("Почта введена неправильно");
        if (errors.Length > 0) return errors.ToString();
        if (obj.UserID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.UserID);
        return "Ok";
    }
}
