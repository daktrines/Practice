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
using Масивы;

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
        int[] mas;
        int[,] matr;
        int[] array;

        DispatcherTimer _timer;// Описываем таймер
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

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Калион Екатерина " +
                "\n1.Ввести трехзначное число. Определить: верно ли, что все его цифры одинаковые ?" +
                "\n2.Ввести три целых числа.Найти количество положительных и отрицательных чисел." +
                "\n3.Дан массив.Определить на сколько максимальный элемент больше минимального." +
                "\n4.Сформировать одномерный массив из количества элементов в диапазоне" +
                "\nзначений а - b строк матрицы.", "Информация", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        //Закрытие программы
        private void Windows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы желаете выйти из программы?", "Выход из программы", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) e.Cancel = true;//Если нет, то мы не выходим из программы
        }

        //Выход из программы
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Расчет задания №1
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
        private void Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            Rez.Clear();
        }

        //Расчет задания №2
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
        private void Value1AndValue2AndValue3_TextChanged(object sender, TextChangedEventArgs e)
        {
            KolPositive.Clear();
            KolNegative.Clear();
        }

        //Расчет задания №3
        private void CalculationOfTheThirdNumber_Click(object sender, RoutedEventArgs e)
        {
            KolStrok.Focus();
            Rez1.Clear();

            if (mas == null || mas.Length == 0)
            {
                MessageBox.Show("Вы не создали матрицу, укажите размеры матрицы и нажмите кнопку Заполнить", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    int rez = Class1.Calculate3(mas);
                    Rez1.Text = Convert.ToString(rez);
                }
                catch
                {
                    MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                      MessageBoxImage.Error);
                    KolStrok.Focus();
                }
            }
        }

        //Заполнение массива
        private void FillArray_Click(object sender, RoutedEventArgs e)
        {
            //Проверка поля на корректность введенных данных
            try
            {
                int count = Convert.ToInt32(KolStrok.Text);

                //задаем массиву размерность
                mas = new int[count];

                //Заполняем массив случайными числами
                Random rnd = new Random();
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = rnd.Next(-10, 100);
                }

                //Выводим матрицу на форму
                MasData.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;

                //очищаем результат
                Rez1.Clear();
            }
            catch
            {
                MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                  MessageBoxImage.Error);
                KolStrok.Focus();
            }
        }
        private void KolStrok_TextChanged(object sender, TextChangedEventArgs e)
        {
            MasData.ItemsSource = null;
            Rez1.Clear();
        }

        //Расчет задания №4
        private void CalculationOfTheFourthNumber_Click(object sender, RoutedEventArgs e)
        {
            KolStrok1.Focus();
            if (matr == null || matr.Length == 0)
            {
                MessageBox.Show("Вы не создали матрицу, укажите размеры матрицы и нажмите кнопку Заполнить", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    int a = Convert.ToInt32(A.Text);
                    int b = Convert.ToInt32(B.Text);
                    Class1.Calculate4(matr, a, b, out array);

                    //Выводим матрицу на форму
                    MasDataRez.ItemsSource = VisualArray.ToDataTable(array).DefaultView;
                }
                catch
                {
                    MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                      MessageBoxImage.Error);
                    KolStrok1.Focus();
                }
            }
        }

        //Заполнение матрицы
        private void FillMatrix_Click(object sender, RoutedEventArgs e)
        {
            //Проверка поля на корректность введенных данных
            try
            {
                int row = Convert.ToInt32(KolStrok1.Text);
                int column = Convert.ToInt32(KolStolbcov.Text);

                //задаем матрицы размерность
                matr = new int[row, column];

                //Заполняем матрицу случайными числами
                Random rnd = new Random();
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        matr[i, j] = rnd.Next(-25, 25);
                    }
                }
                //Выводим матрицу на форму
                MatrData.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;

                //очищаем результат
                A.Clear();
                B.Clear();
                MasDataRez.ItemsSource = null;
            }
            catch
            {
                MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                  MessageBoxImage.Error);
                KolStrok1.Focus();
            }
        }

        //Редактирование ячеек
        private void MatrData_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MasDataRez.ItemsSource = null;

            //Определяем номер столбца
            int columnIndex = e.Column.DisplayIndex;
            //Определяем номер строки
            int rowIndex = e.Row.GetIndex();

            //Заносим  отредоктированое значение в соответствующую ячейку матрицы
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out matr[rowIndex, columnIndex]))
            { }
            else MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }
        private void KolStrok1AndKolStolbcov_TextChanged(object sender, TextChangedEventArgs e)
        {
            MatrData.ItemsSource = null;
            MasDataRez.ItemsSource = null;
            A.Clear();
            B.Clear();
        }

        //Очищение 
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            //Очищаем 
            Value.Clear();
            Rez.Clear();
            Value.Focus();

            Value1.Clear();
            Value2.Clear();
            Value3.Clear();
            KolPositive.Clear();
            KolNegative.Clear();
            Value1.Focus();

            KolStrok.Clear();
            Rez1.Clear();
            MasData.ItemsSource = null;
            KolStrok.Focus();

            KolStrok1.Clear();
            KolStolbcov.Clear();
            A.Clear();
            B.Clear();
            MatrData.ItemsSource = null;
            MasDataRez.ItemsSource = null;
            KolStrok1.Focus();  
        }
    }
}
