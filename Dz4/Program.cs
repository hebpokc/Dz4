using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov_Lab5
{
    class Program
    {
        static int LargestOf(int a, int b)
        {
            return a > b ? a : b;
        }
        static void SwapNumbers(ref double num1, ref double num2)
        {
            double num3 = num1;
            num1 = num2;
            num2 = num3;
        }
        static bool Factorial(int a, out long b)
        {
            b = 1;
            try
            {
                checked
                {
                    for (int i = 1; i <= a; i++)
                    {
                        b *= i;
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВозникло переполнение. Попробуйте ввести число поменьше");
                return false;
            }
        }
        static long RecursiveFactorial(int n)
        {
            try
            {
                checked
                {
                    if (n == 0) return 1;
                    return n == 1 ? 1 : n * RecursiveFactorial(n - 1);
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВозникло переполнение. Попробуйте ввести число поменьше");
                return 0;
            }
        }
        static int NOD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            return a + b;
        }
        static int NOD(int a, int b, int c)
        {
            int temp = NOD(a, b);
            return NOD(temp, c);
        }
        static int Fibonachi(int n)
        {
            if (n == 0 || n == 1) return n;

            return Fibonachi(n - 1) + Fibonachi(n - 2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 5.1");
            Console.WriteLine("Введите два числа: ");
            int number1, number2;
            while (!int.TryParse(Console.ReadLine(), out number1) || !int.TryParse(Console.ReadLine(), out number2))
            {
                Console.WriteLine("Вы ввели не число или не целое число");
            }
            Console.WriteLine($"\nНаибольшее из чисел {number1} и {number2} - это {LargestOf(number1, number2)}");

            Console.WriteLine("\nУпражнение 5.2");
            Console.WriteLine("Введите два числа: ");
            double num1, num2;
            while (!double.TryParse(Console.ReadLine(), out num1) || !double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Вы ввели не число");
            }
            SwapNumbers(ref num1, ref num2);
            Console.WriteLine($"\nЧисла после смены: \n{num1}\n{num2}");

            Console.WriteLine("\nУпражнение 5.3");
            Console.Write("Введите число, факториал которого вам нужен: ");
            int num;
            long result;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Вы ввели не число или не целое число");
            }
            if (Factorial(num, out result))
            {
                Console.WriteLine($"\nФакториал {num} = {result}");
            }

            Console.WriteLine("\nУпражнение 5.4");
            Console.Write("Введите число, факториал которого вам нужен: ");
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Вы ввели не число или не целое число");
            }
            if (RecursiveFactorial(num) != 0)
            {
                Console.WriteLine($"\nФакториал {num} = {RecursiveFactorial(num)}");
            }

            Console.WriteLine("\nДом. Задание 5.1");
            Console.WriteLine("Введите 2 числа для нахождения НОД: ");

            while (!int.TryParse(Console.ReadLine(), out number1) || !int.TryParse(Console.ReadLine(), out number2))
            {
                Console.WriteLine("Вы ввели не число или не целое число");
            }

            Console.WriteLine($"\nНОД чисел {number1} и {number2} = {NOD(number1, number2)}");
            Console.WriteLine("\nВведите 3 числа для нахождения НОД: ");
            int number3;

            while (!int.TryParse(Console.ReadLine(), out number1) || !int.TryParse(Console.ReadLine(), out number2) || !int.TryParse(Console.ReadLine(), out number3))
            {
                Console.WriteLine("Вы ввели не число или не целое число");
            }
            Console.WriteLine($"\nНОД чисел {number1}, {number2}, {number3} = {NOD(number1, number2, number3)}");

            Console.WriteLine("\nДом. Задание 5.2");
            Console.Write($"Введите число из ряда Фибоначчи: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Вы ввели не число или не целое число");
            }
            Console.WriteLine($"\nЗначение {number}-го числа ряда Фибоначчи = {Fibonachi(number)}");

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
