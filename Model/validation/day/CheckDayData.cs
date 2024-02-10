namespace Model.validation.day;

public class CheckDayData : IDayOfWeekValidation
{
    public string ValidateDayOfWeek(string dayOfWeek)
    {
        return dayOfWeek switch
        {
            "1" or "понедельник" or "пн" => "Monday",
            "2" or "вторник" or "вт" => "Tuesday",
            "3" or "среда" or "ср" => "Wednesday",
            "4" or "четверг" or "чт" => "Thursday",
            "5" or "пятница" or "пт" => "Friday",
            "6" or "суббота" or "сб" => "Saturday",
            "7" or "воскресенье" or "вс" => "Sunday",
            _ => "data is empty or incorrect"
        };
    }
}
