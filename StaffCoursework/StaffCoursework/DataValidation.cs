using System.Text.RegularExpressions;

namespace StaffCoursework
{
    public static class DataValidation
    {
        public static bool NameSurname(string text)
        {
            Regex reg = new Regex("^[АБВГҐДЕЄЖЗІЇЙКЛМНОПРСТУФХЦЧШЩЮЯ]{1}[абвгґдеєжзиіїйклмнопрстуфхцчшщюяь']+$");
            Match m = reg.Match(text);
            if (m.Success)
                return true;
            return false;
        }
        public static bool Date(string text)
        {
            Regex reg = new Regex(@"^(\d{2})\.(\d{2})\.(\d{4})$");
            Match m = reg.Match(text);

            if (m.Success)
            {
                int dd = int.Parse(text.Split('.')[0]);
                int mm = int.Parse(text.Split('.')[1]);
                if (dd >= 1 && dd <= 31 && mm >= 1 && mm <= 12)
                    return true;
                return false;
            }
            return false;
        }
        public static bool DepartmentProject(string text)
        {
            Regex reg = new Regex("^([АБВГҐДЕЄЖЗІЇЙКЛМНОПРСТУФХЦЧШЩЮЯ]+[абвгґдеєжзиіїйклмнопрстуфхцчшщюяь ']*)+$");
            Match m = reg.Match(text);
            if (m.Success)
                return true;
            return false;
        }
        public static bool Decimal(string text)
        {
            Regex reg = new Regex(@"^\d+(,\d+){0,1}$");
            Match m = reg.Match(text);
            if (m.Success)
                return true;
            return false;
        }
    }
}
