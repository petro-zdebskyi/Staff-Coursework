using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StaffCoursework
{
    /// <summary>
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public Delete()
        {
            InitializeComponent();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // перевіряємо чи хоча б один прапорець встановлено
            bool falg = SurnameCheckBox.IsChecked == true || NameCheckBox.IsChecked == true || BirthdayCheckBox.IsChecked == true || DateOfEmploymentCheckBox.IsChecked == true || DepartmentCheckBox.IsChecked == true || ProjectCheckBox.IsChecked == true || SalaryCheckBox.IsChecked == true;
            if (!falg)
            {
                MessageBox.Show("Потрібно задати хоча б один критерій видалення. Критерій повинен бути правильним.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            // створюємо масив для передачі у функцію
            var textBoxes = new List<TextBox>();
            textBoxes.Add(DeleteSurnameTextBox);
            textBoxes.Add(DeleteNameTextBox);
            textBoxes.Add(DeleteBirthdayTextBox);
            textBoxes.Add(DeleteDateOfEmploymentTextBox);
            textBoxes.Add(DeleteDepartmentTextBox);
            textBoxes.Add(DeleteProjectTextBox);
            textBoxes.Add(DeleteSalaryTextBox);

            Tasks.DeleteItemFunc(MainWindow.Workers, textBoxes);

            // обновлюємо таблицю
            var window2 = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            window2.Refresh();

            // перевіряємо чи масив порожній і робимо недоступними необхідні елементи
            if (MainWindow.Workers.Count > 0)
            {
                window2.DeleteMenuItem.IsEnabled = true;
                window2.ContextDelete.IsEnabled = true;
                window2.SaveMenu.IsEnabled = true;
                window2.TasksMenu.IsEnabled = true;
            }
            else
            {
                window2.DeleteMenuItem.IsEnabled = false;
                window2.ContextDelete.IsEnabled = false;
                window2.SaveMenu.IsEnabled = false;
                window2.TasksMenu.IsEnabled = false;
            }
        }
        private void DeleteSurnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            // робимо перевірку правильності вводу даних
            if (DataValidation.NameSurname(textBox.Text))
            {
                textBox.Background = Brushes.Aqua;
                SurnameCheckBox.IsChecked = true;
            }
            else
            {
                textBox.Background = Brushes.White;
                SurnameCheckBox.IsChecked = false;
            }
        }
        private void DeleteNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            // робимо перевірку правильності вводу даних
            if (DataValidation.NameSurname(textBox.Text))
            {
                textBox.Background = Brushes.Aqua;
                NameCheckBox.IsChecked = true;
            }
            else
            {
                textBox.Background = Brushes.White;
                NameCheckBox.IsChecked = false;
            }
        }
        private void DeleteBirthdayTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            // робимо перевірку правильності вводу даних
            if (DataValidation.Date(textBox.Text))
            {
                textBox.Background = Brushes.Aqua;
                BirthdayCheckBox.IsChecked = true;
            }
            else
            {
                textBox.Background = Brushes.White;
                BirthdayCheckBox.IsChecked = false;
            }
        }
        private void DeleteDateOfEmploymentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            // робимо перевірку правильності вводу даних
            if (DataValidation.Date(textBox.Text))
            {
                textBox.Background = Brushes.Aqua;
                DateOfEmploymentCheckBox.IsChecked = true;
            }
            else
            {
                textBox.Background = Brushes.White;
                DateOfEmploymentCheckBox.IsChecked = false;
            }
        }
        private void DeleteDepartmentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            // робимо перевірку правильності вводу даних
            if (DataValidation.DepartmentProject(textBox.Text))
            {
                textBox.Background = Brushes.Aqua;
                DepartmentCheckBox.IsChecked = true;
            }
            else
            {
                textBox.Background = Brushes.White;
                DepartmentCheckBox.IsChecked = false;
            }
        }
        private void DeleteProjectTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            // робимо перевірку правильності вводу даних
            if (DataValidation.DepartmentProject(textBox.Text))
            {
                textBox.Background = Brushes.Aqua;
                ProjectCheckBox.IsChecked = true;
            }
            else
            {
                textBox.Background = Brushes.White;
                ProjectCheckBox.IsChecked = false;
            }
        }
        private void DeleteSalaryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            // робимо перевірку правильності вводу даних
            if (DataValidation.Decimal(textBox.Text))
            {
                textBox.Background = Brushes.Aqua;
                SalaryCheckBox.IsChecked = true;
            }
            else
            {
                textBox.Background = Brushes.White;
                SalaryCheckBox.IsChecked = false;
            }
        }
    }
}
