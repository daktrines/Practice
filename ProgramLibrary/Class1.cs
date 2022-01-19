using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLibrary
{
    public class Class1
    {
        /// <summary>
        /// Решение 4-х заданий по учебной практике
        /// Расчет 1 задания: Ввести трехзначное число. Определить: верно ли, что все его цифры одинаковые?
        /// </summary>
        /// <param name="value"> трехзначное число </param>
        /// <returns></returns>
        public static bool Calculate1(int value)
        {
            bool da;
            int value1 = value % 10;
            value = value / 10;
            int value2 = value % 10;
            value = value / 10;
            int value3 = value % 10;
            if (value1 == value2 && value1 == value3) da = true;
            else da = false;
            return da;
        }

        /// <summary>
        /// Расчет 2 задания: Ввести три целых числа. Найти количество положительных и отрицательных чисел
        /// </summary>
        /// <param name="value1"> первое натуральное число </param>
        /// <param name="value2"> второе натуральное число </param>
        /// <param name="value3"> третье натуральное число </param>
        /// <param name="kol"> количество положительных чисел </param>
        /// <param name="kol1"> количество отрицательных чисел </param>
        public static void Calculate2(int value1, int value2, int value3, out int kol, out int kol1)
        {
            kol = 0; kol1 = 0;
            if (value1 > 0) kol++;
            else kol1++;
            if (value2 > 0) kol++;
            else kol1++;
            if (value3 > 0) kol++;
            else kol1++;
        }

        /// <summary>
        /// Расчет 3 задания: Дан массив. Определить на сколько максимальный элемент больше минимального
        /// </summary>
        /// <param name="mas"> одномерный массив </param>
        /// <returns></returns>
        public static int Calculate3(int [] mas )
        {
            int minvalue = 1000, maxvalue = 0, rez = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > maxvalue) maxvalue = mas[i];
            
                if (mas[i] < minvalue) minvalue = mas[i];
            }
            rez = maxvalue - minvalue;
            return rez;
        }

        /// <summary>
        /// Расчет 4 задания: Сформировать одномерный массив из количества элементов в диапазоне значений а-b строк матрицы
        /// </summary>
        /// <param name="matr"> двумерный массив </param>
        /// <param name="a"> с этого числа начинается диапазон </param>
        /// <param name="b"> этим числом заканчиваестя диапазон </param>
        /// <param name="array"> одномерный массив </param>
        public static void Calculate4(int[,] matr, int a, int b, out int [] array)
        {
            int count = 0, k = 0;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for(int j = 0; j < matr.GetLength(1); j++)
                {
                    if (matr[i, j] > a && matr[i, j] < b) count++;
                }
            }
            array = new int[count];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    if (matr[i, j] > a && matr[i, j] < b)
                    {
                        array[k] = matr[i, j];
                        k++;
                    }
                }
            }
        }
    }
}
