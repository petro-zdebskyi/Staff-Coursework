using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StaffCoursework
{
    public static class Tasks
    {
        public static void SortByDateOfEmploymentFunc(List<Worker> workers)
        {
            // сортуємо працівників за полем дати працевлаштування використовуючи лямда-вираз
            workers.Sort((Worker x, Worker y) => x.DateOfEmployment.CompareTo(y.DateOfEmployment));
        }
        public static void ProjectsInDepartmentFunc(List<Worker> workers, TextBox textbox)
        {
            string text = "";
            int i = 1;// задає порядковий номер у списку
            bool flag = false;

            // проходимось по всіх елементах головного масиву
            foreach (var el in workers)
            {
                if (el.Department == textbox.Text)
                {
                    flag = true;
                    text += String.Format(i++.ToString() + ") " + el.Project + "\n"); // записуємо в змінну назву проекту
                }
            }
            if (flag)
                MessageBox.Show(text, "Список проектів");
            else
                MessageBox.Show("Немає такого відділу", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void DepartmentsByBirthdayFunc(List<Worker> workers, TextBox textbox)
        {
            string text = "";
            int i = 1;// задає порядковий номер у списку
            bool flag = false;

            // проходимось по всіх елементах головного масиву
            foreach (var el in workers)
            {
                if (el.Birthday.ToString("dd/MM/yyyy") == textbox.Text)
                {
                    flag = true;
                    text += String.Format(i++.ToString() + ") " + el.Department + "\n");// записуємо в змінну назву відділу
                }
            }
            if (flag)
                MessageBox.Show(text, "Список відділів");
            else
                MessageBox.Show("Немає працівника з такою датою народження", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void ProjectWhereJoungestOldestFunc(List<Worker> workers)
        {
            var min = DateTime.MaxValue;
            var max = DateTime.MinValue;

            // змінні у які буде записано назви проектів наймолодшого та найстаршого працівника відповідно
            string minText = "";
            string maxText = "";

            // проходимось по всіх елементах головного масиву
            foreach (var el in workers)
            {
                if (el.DateOfEmployment < min)
                {
                    min = el.DateOfEmployment;
                    minText = el.Project.ToString();
                    continue;
                }
                if (el.DateOfEmployment > max)
                {
                    max = el.DateOfEmployment;
                    maxText = el.Project.ToString();
                }
            }
            MessageBox.Show("Проект, в якому працює наймолодший працівник : " + minText + "\nПроект, в якому працює найстарший працівник : " + maxText, "Завдання №4");
        }
        public static void SortBySalaryFunc(List<Worker> workers)
        {
            // сортуємо працівників за полем заробітня плата використовуючи лямда-вираз
            workers.Sort((Worker x, Worker y) => x.Salary.CompareTo(y.Salary));
        }
        public static void AddItemFunc(List<Worker> workers, List<TextBox> textboxes)
        {
            try
            {

                // створюємо нового працівника записуємо потрібні дані та добавляємо до головного масиву працівників
                workers.Add(new Worker
                {
                    Surname = textboxes[0].Text,
                    Name = textboxes[1].Text,
                    Birthday = Convert.ToDateTime(textboxes[2].Text),
                    DateOfEmployment = Convert.ToDateTime(textboxes[3].Text),
                    Department = textboxes[4].Text,
                    Project = textboxes[5].Text,
                    Salary = Double.Parse(textboxes[6].Text)
                });
            }
            catch (WorkerException ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }
        public static void DeleteItemFunc(List<Worker> workers, List<TextBox> textboxes)
        {
            int startCount = workers.Count; // початкова довжина масиву
            int notEmptyCount = 0;// кількість непорожніх текстових полів

            // підраховуємо кількість непорожніх текстових полів
            foreach (var el in textboxes)
            {
                if (el.Text != String.Empty)
                    notEmptyCount++;
            }

            int countAppropriate = 0;// кількість параметрів працівника які задовільняють умову

            // підраховуємо кількість параметрів працівника які задовільняють умову
            for (int i = workers.Count - 1; i >= 0; i--)
            {
                countAppropriate = 0;
                if (workers[i].Surname == textboxes[0].Text)
                    countAppropriate++;
                if (workers[i].Name == textboxes[1].Text)
                    countAppropriate++;
                if (workers[i].Birthday.ToString("dd.MM.yyyy") == textboxes[2].Text)
                    countAppropriate++;
                if (workers[i].DateOfEmployment.ToString("dd.MM.yyyy") == textboxes[3].Text)
                    countAppropriate++;
                if (workers[i].Department == textboxes[4].Text)
                    countAppropriate++;
                if (workers[i].Project == textboxes[5].Text)
                    countAppropriate++;
                if (workers[i].Salary.ToString() == textboxes[6].Text)
                    countAppropriate++;

                // перевіряємо чи кількість непорожніх текстових полів рівна кількості параметрів працівника які задовільняють умову
                if (countAppropriate == notEmptyCount)
                    workers.RemoveAt(i); // видаляємо елемент за індексом
            }
            if (workers.Count == startCount)
                MessageBox.Show("Не знайдено працівника з такими даними", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
