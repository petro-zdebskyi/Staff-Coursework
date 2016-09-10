using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StaffCoursework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Worker> Workers;//декларація статичного масиву працівників
        public MainWindow()
        {
            InitializeComponent();
            Workers = new List<Worker>();// ініціалізація статичного масиву працівників
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = ""; // Ім'я за замовчуванням
                dlg.DefaultExt = ".txt"; // Тип файлів за замовчуванням
                dlg.Filter = "Текстові документи|*.txt|XML документи|*.xml"; // фільтр документів

                // відкриття документу
                Nullable<bool> result = dlg.ShowDialog();
                string path = "";

                if (result == true)
                {
                    path = dlg.FileName;
                }
                else
                    throw new Exception("Помилка при знаходженні файлу.");

                // у змінну lines записуємо весь текст з файлу, шлях до якого заданий змінною path
                var lines = File.ReadAllLines(path);

                IEnumerable<Worker> data;
                try
                {
                    // заповнюємо масив data працівниками
                    data = from l in lines
                           let split = l.Split('\t')
                           select new Worker
                           {
                               Surname = split[0],
                               Name = split[1],
                               Birthday = Convert.ToDateTime(split[2]),
                               DateOfEmployment = Convert.ToDateTime(split[3]),
                               Department = split[4],
                               Project = split[5],
                               Salary = Double.Parse(split[6])
                           };
                    Workers = data.ToList();
                }
                catch (WorkerException ex)
                {
                    throw new Exception("Помилка при відкритті файлу. " + ex.Message);
                }
                // заповнюємо таблицю працівниками
                MainGrid.ItemsSource = Workers;

                // задаємо імена стовпців
                MainGrid.Columns[0].Header = "Прізвище";
                MainGrid.Columns[1].Header = "Ім'я";
                MainGrid.Columns[2].Header = "Дата народження";
                MainGrid.Columns[3].Header = "Дата працевлаштування";
                MainGrid.Columns[4].Header = "Відділ";
                MainGrid.Columns[5].Header = "Проект";
                MainGrid.Columns[6].Header = "Заробітня плата";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            finally
            {
                // перевіряємо чи масив порожній і робимо недоступними необхідні елементи
                if (MainWindow.Workers.Count > 0)
                {
                    DeleteMenuItem.IsEnabled = true;
                    ContextDelete.IsEnabled = true;
                    SaveMenu.IsEnabled = true;
                    TasksMenu.IsEnabled = true;
                }
                else
                {
                    DeleteMenuItem.IsEnabled = false;
                    ContextDelete.IsEnabled = false;
                    SaveMenu.IsEnabled = false;
                    TasksMenu.IsEnabled = false;
                }
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "NewStaffFile"; // Ім'я файлу за замовчуванням
            dlg.DefaultExt = ".txt"; // Тип файлу за замовчуванням
            dlg.Filter = "Текстові документи|*.txt|XML документи|*.xml"; // фільтр файлів

            // записуємо усі елементи головного масиву у змінну text
            string text = "";
            foreach(Worker el in Workers)
            {
                text += String.Format(el.Surname + "\t");
                text += String.Format(el.Name + "\t");
                text += String.Format(el.Birthday.ToString("dd.MM.yyyy") + "\t");
                text += String.Format(el.DateOfEmployment.ToString("dd.MM.yyyy") + "\t");
                text += String.Format(el.Department + "\t");
                text += String.Format(el.Project + "\t");
                text += String.Format(el.Salary + Environment.NewLine);

            }
            // якщо діалог збереженння вдало відкрився записуємо змінну text у файл
            if (dlg.ShowDialog() == true)
                File.WriteAllText(dlg.FileName, text);
        }
        private void MainGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // задаємо формат виведення дати
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";
        }
        private void MainGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // при подвійному натисканні відкриваємо діалогове вікно відкриття файлу
            Open_Click(this, null);
        }
        private void ProjectsInDepartment_Click(object sender, RoutedEventArgs e)
        {
            // при натисканні створюємо і показуємо вікно класу ProjectsInDepartment
            ProjectsInDepartment obj = new ProjectsInDepartment();
            obj.Show();
        }
        private void DepartmentsByBirthday_Click(object sender, RoutedEventArgs e)
        {
            // при натисканні створюємо і показуємо вікно класу DepartmentsByBirthday
            DepartmentsByBirthday obj = new DepartmentsByBirthday();
            obj.Show();
        }
        private void ProjectWhereYoungestOldest(object sender, RoutedEventArgs e)
        {
            // викликаємо статичний метод знаходження відображення проектів наймолодшого та найстаршого працівника
            Tasks.ProjectWhereJoungestOldestFunc(MainWindow.Workers);
        }
        public void Refresh()
        {
            // перезаписуємо таблицю
            MainGrid.ItemsSource = null;
            MainGrid.ItemsSource = Workers;

            // задаємо назви сповпців
            MainGrid.Columns[0].Header = "Прізвище";
            MainGrid.Columns[1].Header = "Ім'я";
            MainGrid.Columns[2].Header = "Дата народження";
            MainGrid.Columns[3].Header = "Дата працевлаштування";
            MainGrid.Columns[4].Header = "Відділ";
            MainGrid.Columns[5].Header = "Проект";
            MainGrid.Columns[6].Header = "Заробітня плата";
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // перевіряємо чи головний масив не порожній
            if (Workers.Count == 0)
                return;

            // надаємо можливість збереженя змін
            var result =  MessageBox.Show("Зберегти зміни внесені до таблиці?", "Зберегти", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                Save_Click(this, null);
        }
        private void AddElement_Click(object sender, RoutedEventArgs e)
        {
            // при натисканні створюємо і показуємо вікно додавання нового елемента
            Add obj = new Add();
            obj.Show();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // при натисканні створюємо і показуємо вікно видалення елемента
            Delete obj = new Delete();
            obj.Show();
        }
        private void ContextAdd(object sender, RoutedEventArgs e)
        {
            AddElement_Click(this, null);
        }
        private void ContextDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete_Click(this, null);
        }
        private void InfoMenu_Click(object sender, RoutedEventArgs e)
        {
            // при натисканні створюємо і показуємо вікно інформації про програму
            Info obj = new Info();
            obj.Show();
        }
        private void SortBySalaryMenu(object sender, RoutedEventArgs e)
        {
            Tasks.SortBySalaryFunc(Workers);
            Refresh();
        }
        private void SortByDateOfEmploymentMenu(object sender, RoutedEventArgs e)
        {
            // викликаємо стакичний метод сортування працівників за датою працевлаштування
            Tasks.SortByDateOfEmploymentFunc(Workers);
            Refresh();
        }
        private void HelpMenu_Click(object sender, RoutedEventArgs e)
        {
            // при натисканні створюємо і показуємо вікно довідки
            Help obj = new Help();
            obj.Show();
        }
    }
}