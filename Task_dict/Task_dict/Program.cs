using System;
using System.IO;

namespace Task_dict
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите буквы для поиска без пробела:");


            // Ввод исходных букв
            string s;
            s = Console.ReadLine();


            // Открытие файла
            StreamReader sr = File.OpenText("Text.txt");
            

            Console.WriteLine();


            while (!sr.EndOfStream)
            {
                // Чтение строки
                string st = sr.ReadLine();


                // Создаем копии строк
                string s1, st1;


                s1 = s;
                st1 = st;


                // Проверка на совпадение букв
                for (int i = 0; i < s1.Length; i++)
                {
                    for (int l = 0; l < st1.Length; l++)
                    {
                        if (s1[i] == st1[l])
                        {
                            s1 = s1.Remove(i, 1);
                            st1 = st1.Remove(l, 1);
                            i--;
                            l--;
                            break;
                        }
                    }
                }


                // Вывод результата
                if ((s1 == string.Empty) && (st1 == string.Empty))
                {
                    Console.WriteLine(st);
                }
            }


            Console.WriteLine("Конец работы. Для продолжения нажмите любую клавишу...");
            Console.ReadLine();
        }
    }
}

