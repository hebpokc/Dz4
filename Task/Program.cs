using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task
{
    class Program
    {
        static bool InArray(int[] array, int num)
        {
            foreach (int item in array)
            {
                if (item == num)
                {
                    return true;
                }
            }
            return false;
        }
        static void Swap(int[] array, int num1, int num2)
        {
            int index1 = Array.IndexOf(array, num1);
            int index2 = Array.IndexOf(array, num2);

            array[index1] = num2;
            array[index2] = num1;
        }
        static int ActionsWithArray(ref int mult, out double average, params int[] arr)
        {
            int sum = 0;

            foreach(int i in arr)
            {
                sum += i;
                mult *= i;
            }
            average = (double)sum / arr.Length;
            return sum;
        }
        static void DrawNumber(byte num)
        {
            switch(num)
            {
                case 0:
                    {
                        Console.WriteLine("\n#### \n#  #\n#  #\n#  #\n####");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("\n# \n# \n# \n# \n#");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("\n####\n   #\n####\n#\n####");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("\n####\n   #\n####\n   #\n####");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("\n#  #\n#  #\n####\n   #\n   #");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("\n####\n#\n###\n   #\n###");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("\n####\n#\n####\n#  #\n####");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("\n####\n   #\n  #\n ###\n  #");
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("\n####\n#  #\n####\n#  #\n####");
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("\n####\n#  #\n####\n   #\n####");
                        break;
                    }
            }
        }
        enum GrumpinessLevel
        {
            Неворчливый,
            Немного_ворчливый,
            Средне_ворчливый,
            Сильно_ворчливый
        }
        struct OldMan
        {
            public string name;
            public GrumpinessLevel GL;
            public string[] phrases;
            public int bruises;
            public OldMan(string n, GrumpinessLevel g, string[] p)
            {
                name = n;
                GL = g;
                phrases = p;
                bruises = 0;
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {name}\nУровень ворчливости: {GL}");
            }
            public int CheckPhrases(params string[] swearing)
            {
                foreach(string phr in phrases)
                {
                    foreach(string word in swearing)
                    {
                        if (phr.Contains(word))
                        {
                            bruises++;
                        }
                    }
                }
                return bruises;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine("Сгенерированный массив: ");
            int[] arr = new int[20];
            int number1, number2;
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                arr[i] = rnd.Next(-50, 50);
                Console.WriteLine(arr[i]);
            }

            Console.WriteLine("\nВведите 2 числа из массива для их смены: ");
            if (int.TryParse(Console.ReadLine(), out number1) && int.TryParse(Console.ReadLine(), out number2))
            {
                if (InArray(arr, number1) && InArray(arr, number2))
                {
                    Console.WriteLine("\nМассив после смены чисел: ");
                    Swap(arr, number1, number2);

                    foreach (int i in arr)
                    {
                        Console.WriteLine(i);
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели числа не содержащиеся в массиве");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число или не целое число");
            }

            Console.WriteLine("\nЗадание 2");
            Console.WriteLine("Сгенерированный массив: ");
            int[] arr2 = new int[5];
            int sum;
            int mult = 1;
            double average;
            for (int i = 0; i < 5; i++)
            {
                arr2[i] = rnd.Next(-25, 25);
                Console.WriteLine(arr2[i]);
            }
            sum = ActionsWithArray(ref mult, out average, arr2);
            Console.WriteLine($"\nСумма элементов массива: {sum}\nПроизведение массива: {mult}\nСреднее арифметическое в массиве: {average}");

            Console.WriteLine("\nЗадание 3");
            Console.Write("Введите цифру от 0 до 9 или закрыть/exit для завершения программы: ");
            byte num;
            string input;
            bool flag = true;

            while (flag)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "закрыть" || input.ToLower() == "exit")
                {
                    //Environment.Exit(0);
                    flag = false;
                }
                else
                {
                    try
                    {
                        if (byte.TryParse(input, out num))
                        {
                            if (0 <= num && num <= 9)
                            {
                                DrawNumber(num);
                                Console.WriteLine();
                            }
                            else
                            {
                                throw new Exception("\nВы ввели цифру не от 0 до 9");
                            }
                        }
                        else
                        {
                            throw new Exception("\nВы ввели не цифру");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Thread.Sleep(3000);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
            }

            Console.WriteLine("\nЗадание 4");
            Console.WriteLine("Информация о дедах: ");

            string[] swearings = { "Пидор", "Сука", "Долбоеб", "Блять"};
            string[] phrase1 = { "Проститутки", "Гады" };
            string[] phrase2 = { "Дурак", "Осел", "Пидор", "Сука" };
            string[] phrase3 = { "Лох", "Сука", "Блять", "Долбоеб", "Гнида" };
            string[] phrase4 = { "Щенок", "Глиста", "Пень" };
            string[] phrase5 = { "Мальчик", "Сорванец"};

            OldMan[] oldMans = new OldMan[5];
            oldMans[0] = new OldMan("Иван", GrumpinessLevel.Неворчливый, phrase5);
            oldMans[1] = new OldMan("Евгений", GrumpinessLevel.Немного_ворчливый, phrase4);
            oldMans[2] = new OldMan("Олег", GrumpinessLevel.Сильно_ворчливый, phrase3);
            oldMans[3] = new OldMan("Павел", GrumpinessLevel.Средне_ворчливый, phrase2);
            oldMans[4] = new OldMan("Серега", GrumpinessLevel.Немного_ворчливый, phrase1);

            Console.WriteLine($"\nДед {oldMans[0].name} получил {oldMans[0].CheckPhrases(swearings)} синяк/ов. ");
            Console.WriteLine($"\nДед {oldMans[1].name} получил {oldMans[1].CheckPhrases(swearings)} синяк/ов. ");
            Console.WriteLine($"\nДед {oldMans[2].name} получил {oldMans[2].CheckPhrases(swearings)} синяк/ов. ");
            Console.WriteLine($"\nДед {oldMans[3].name} получил {oldMans[3].CheckPhrases(swearings)} синяк/ов. ");
            Console.WriteLine($"\nДед {oldMans[4].name} получил {oldMans[4].CheckPhrases(swearings)} синяк/ов. ");

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
