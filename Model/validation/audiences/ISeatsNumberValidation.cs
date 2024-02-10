namespace Model.validation.audiences;

public interface ISeatsNumberValidation
{
    bool ValidateSeatsNumber(int? seatsNumber);
}
