namespace Model.validation.users;

public interface IValidationPassword
{
    bool ValidatePassword(string password);
}
