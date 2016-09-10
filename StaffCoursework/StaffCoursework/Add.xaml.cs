using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StaffCoursework
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // перевіряємо чи всі прапорці встановлено
            if (SurnameCheckBox.IsChecked == false && NameCheckBox.IsChecked == false && BirthdayCheckBox.IsChecked == false && DateOfEmploymentCheckBox.IsChecked == false && DepartmentCheckBox.IsChecked == false && ProjectCheckBox.IsChecked == false && SalaryCheckBox.IsChecked == false)
            {
                MessageBox.Show("Потрібно заповнити всі поля", "Помилка", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            // створюємо масив щоб передати його пізніше у функцію
            var textBoxes = new List<TextBox>();
            textBoxes.Add(AddSurnameTextBox);
            textBoxes.Add(AddNameTextBox);
            textBoxes.Add(AddBirthdayTextBox);
            textBoxes.Add(AddDateOfEmploymentTextBox);
            textBoxes.Add(AddDepartmentTextBox);
            textBoxes.Add(AddProjectTextBox);
            textBoxes.Add(AddSalaryTextBox);

            // виклик статичного методу 
            Tasks.AddItemFunc(MainWindow.Workers, textBoxes);

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
        private void AddSurnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            // робимо перевірку правильності вводу даних
            if (DataValidation.NameSurname(textBox.Text))
            {
                textBox.Background = Brushes.Aqua;// змінюємо колір текстового поля
                SurnameCheckBox.IsChecked = true;// встановлюємо прапорець
            }
            else
            {
                textBox.Background = Brushes.White;
                SurnameCheckBox.IsChecked = false;
            }
        }
        private void AddNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
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
        private void AddBirthdayTextBox_TextChanged(object sender, TextChangedEventArgs e)
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
        private void AddDateOfEmploymentTextBox_TextChanged(object sender, TextChangedEventArgs e)
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
        private void AddDepartmentTextBox_TextChanged(object sender, TextChangedEventArgs e)
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
        private void AddProjectTextBox_TextChanged(object sender, TextChangedEventArgs e)
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
        private void AddSalaryTextBox_TextChanged(object sender, TextChangedEventArgs e)
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
