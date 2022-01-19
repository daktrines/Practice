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

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Калион Екатерина " +
                "\n1.Ввести трехзначное число. Определить: верно ли, что все его цифры одинаковые ?" +
                "\n2.Ввести три целых числа.Найти количество положительных и отрицательных чисел." +
                "\n3.Дан массив.Определить на сколько максимальный элемент больше минимального." +
                "\n4.Сформировать одномерный массив из количества элементов в диапазоне" +
                "\nзначений а - b строк матрицы.", "Информация", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

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
        //Редактирование ячеек
        private void MatrData_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Очищаем textbox с результатом 
            Rez1.Clear();

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
        //Расчет задания для матрицы
        private void CalculationOfTheThirdNumber_Click(object sender, RoutedEventArgs e)
        {
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


        //Очищение матрицы
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            //Очищаем остальные текстбоксы
            Value.Clear();
            Value1.Clear();
            Value2.Clear();
            Value3.Clear();
            Rez.Clear();
            A.Clear();
            B.Clear();
            MasDataRez.ItemsSource = null;
            KolPositive.Clear();
            KolNegative.Clear();
            KolStrok.Focus();
            KolStolbcov.Clear();
            KolStrok1.Clear();
            KolStrok.Clear();
            Rez1.Clear();
            MasData.ItemsSource = null;
            MatrData.ItemsSource = null;
        }
        //Заполнение матрицы
        private void FillMatrix_Click(object sender, RoutedEventArgs e)
        {
            //Проверка поля на корректность введенных данных
            try
            {
                int row = Convert.ToInt32(KolStrok1.Text);
                int column = Convert.ToInt32(KolStolbcov.Text);

                //задаем массиву размерность
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
                KolStrok.Focus();
            } 
        }

        //Расчет задания для матрицы
        private void CalculationOfTheFourthNumber_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
