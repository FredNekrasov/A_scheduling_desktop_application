namespace Model.validation.users;

public class CheckUserData : IValidationUserName, IValidationPassword, IValidationEmail
{
    public bool ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email) || !email.Contains('@')) return false; else return true;
    }
    public bool ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 40) return false; else return true;
    }
    public bool ValidateUserName(string userName)
    {
        if (!string.IsNullOrEmpty(userName) && !string.IsNullOrWhiteSpace(userName)) return true; else return false;
    }
}
