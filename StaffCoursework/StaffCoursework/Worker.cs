using System;

namespace StaffCoursework
{
    public class Worker
    {
        #region Приватні поля
        private string surname;
        private string name;
        private DateTime birthday;
        private DateTime dateOfEmployment;
        private string department;
        private string project;
        private double salary;
        #endregion
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                // перевірка правильності введення прізвища
                if (!DataValidation.NameSurname(value))
                    throw new WorkerException("Неправильно введено прізвище. Воно повинне починатись з великої літери.");

                // обмеження довжини 29 символами
                if (value.Length < 30)
                    surname = value;
                else
                    throw new WorkerException("Неправильно введено прізвище. Воно повинне містити менше 30 літер.");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                // перевірка правильності введення імені
                if (!DataValidation.NameSurname(value))
                    throw new WorkerException("Неправильно введено ім'я. Воно повинне починатись з великої літери.");

                // обмеження довжини 29 символами
                if (value.Length < 30)
                    name = value;
                else
                    throw new WorkerException("Неправильно введено ім'я. Воно повинне містити менше 30 літер.");
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                // перевікра правильності введення дня народження
                if (!DataValidation.Date(value.ToString("dd.MM.yyyy")))
                    throw new WorkerException("Неправильно введено дату народження. Вона повинна бути у форматі \"дд.мм.рррр\".");

                int yyyy = int.Parse(value.ToString("dd.MM.yyyy").Split('.')[2]);

                // обмежуємо дату
                if (yyyy > 1800 && yyyy <= DateTime.Now.Year)
                    birthday = Convert.ToDateTime(value);
                else
                    throw new WorkerException("Неправильно введено дату народження. Рік повинен бути більшим ніж 1800 і не більшим від теперішнього року");
            }
        }
        public DateTime DateOfEmployment
        {
            get
            {
                return dateOfEmployment;
            }
            set
            {
                // перевікра правильності введення дати працевлаштування
                if (!DataValidation.Date(value.ToString("dd.MM.yyyy")))
                    throw new WorkerException("Неправильно введено дату працевлаштування. Вона повинна бути у форматі \"дд.мм.рррр\".");

                int yyyy = int.Parse(value.ToString("dd.MM.yyyy").Split('.')[2]);

                // обмежуємо дату
                if (yyyy > 1800 && yyyy <= DateTime.Now.Year)
                    dateOfEmployment = Convert.ToDateTime(value);
                else
                    throw new WorkerException("Неправильно введено дату працевлаштування. Рік повинен бути більшим ніж 1800 і не більшим від теперішнього року");
            }
        }
        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                // перевірка правильності введення відділу
                if (!DataValidation.DepartmentProject(value))
                    throw new WorkerException("Неправильно введено назву відділу. Вона повинна починатися з великої літери.");

                // обмеження довжини 29 символами
                if (value.Length < 30)
                    department = value;
                else
                    throw new WorkerException("Неправильно введено назву відділу. Вона повинна містити менше 30 літер.");
            }
        }
        public string Project
        {
            get
            {
                return project;
            }
            set
            {
                // перевірка правильності введення проекту
                if (!DataValidation.DepartmentProject(value))
                    throw new WorkerException("Неправильно введено назву проекту. Вона повинна починатися з великої літери.");

                // обмеження довжини 29 символами
                if (value.Length < 30)
                    project = value;
                else
                    throw new WorkerException("Неправильно введено назву проекту. Вона повинна містити менше 30 літер.");
            }
        }
        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                // перевірка правильності введення десяткового числа
                if (!DataValidation.Decimal(value.ToString()))
                    throw new WorkerException("Неправильно введено заробітну плату. Вона повинна містити тільки цифри та не більше однієї коми.");

                // обмеження довжини 29 символами
                if (value.ToString().Length < 30)
                    salary = value;
                else
                    throw new WorkerException("Неправильно введено заробітну плату. Вона повинна містити менше 30 символів.");
            }
        }
        public Worker()
        {
            surname = "";
            name = "";
            birthday = DateTime.MinValue;
            dateOfEmployment = DateTime.MinValue;
            department = "";
            project = "";
            salary = 0;
        }
    }
}
