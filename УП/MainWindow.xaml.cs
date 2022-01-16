using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ProgramLibrary;

namespace УП
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Value.Focus();
        }
        DispatcherTimer _timer;// Описываем таймер

        private void CalculationOfTheFirstNumber_Click(object sender, RoutedEventArgs e)
        {
            Value.Focus();
            try
            {
                int value = Convert.ToInt32(Value.Text);
                if (value > 99)
                {
                    bool da = Class1.Calculate1(value);
                    if (da == true) Rez.Text = "Верно (Все цифры одинаковы)";
                    else Rez.Text = "Неверно (Цифры не одинаковы)";
                }
                else
                {
                    MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                      MessageBoxImage.Error);
                    Value.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                  MessageBoxImage.Error);
                Value.Focus();
            }
}

        private void CalculationOfTheSecondNumber_Click(object sender, RoutedEventArgs e)
        {
            Value1.Focus();
            try
            {
                int value1 = Convert.ToInt32(Value1.Text);
                int value2 = Convert.ToInt32(Value2.Text);
                int value3 = Convert.ToInt32(Value3.Text);
                Class1.Calculate2(value1, value2, value3, out int kol, out int kol1);
                KolPositive.Text = Convert.ToString(kol);
                KolNegative.Text = Convert.ToString(kol1);
            }
            catch
            {
                MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                  MessageBoxImage.Error);
                Value1.Focus();
            }
}
        private void CalculationOfTheThirdNumber_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CalculationOfTheFourthNumber_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            //Добавляем таймер
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            _timer.IsEnabled = true;
        }

        //Создаем вручную событие таймера
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;//Создание обьекта
            time.Text = d.ToString("HH:mm");//Время
            date.Text = d.ToString("dd.MM.yyyy");//Дата
        }
    }
}
