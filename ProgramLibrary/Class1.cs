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
        /// <param name="kol1"> количество положительных чисел </param>
        /// <param name="kol2"> количество отрицательных чисел </param>
        public static void Calculate2(int value1, int value2, int value3, out int kol1, out int kol2)
        {
            kol1 = 0; kol2 = 0;
            if (value1 > 0) kol1++;
            else kol2++;
            if (value2 > 0) kol1++;
            else kol2++;
            if (value3 > 0) kol1++;
            else kol2++;
        }
    }
}
