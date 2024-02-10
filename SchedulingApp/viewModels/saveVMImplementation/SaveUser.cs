using Model.entities;
using Model.repositories;
using Model.validation.users;
using System.Text;

namespace SchedulingApp.viewModels.saveVMImplementation;

public class SaveUser(
    IRepository<User> repository,
    IValidationUserName validationUserName,
    IValidationPassword validationPassword,
    IValidationEmail validationEmail
) : ISaveVM<User>
{
    private readonly IRepository<User> _repository = repository;
    private readonly IValidationUserName checkUserName = validationUserName;
    private readonly IValidationPassword checkPassword = validationPassword;
    private readonly IValidationEmail checkEmail = validationEmail;
    public async Task<string> SaveAsync(User obj)
    {
        StringBuilder errors = new();
        bool result = checkUserName.ValidateUserName(obj.UserName);
        if (result == false) errors.AppendLine("Имя пользователя введено неправильно");
        result = checkPassword.ValidatePassword(obj.Password);
        if (result == false) errors.AppendLine("Пароль введен неправильно. Длина пароля должна быть в 8 и более символов");
        result = checkEmail.ValidateEmail(obj.Email);
        if (result == false) errors.AppendLine("Почта введена неправильно");
        if (errors.Length > 0) return errors.ToString();
        if (obj.UserID == 0) await _repository.Create(obj); else await _repository.Update(obj, obj.UserID);
        return "Ok";
    }
}
