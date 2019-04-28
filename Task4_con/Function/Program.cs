using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Function
{
    class Program
    {
        const string YES = @"Да";
        const string NO = @"Нет";
        static void Main(string[] args)
        {
            string finishProgram;
            do
            {
                string resposeConfirm = ReadResponse("Выполнить функцию?", new string[] { YES, NO });
                if (resposeConfirm.Equals(YES))
                {
                    double a, x;
                    string aString, xString;
                    Console.Write(@"Введите a: ");
                    aString = Console.ReadLine();
                    Console.Write(@"Введите x: ");
                    xString = Console.ReadLine();
                    while (!(double.TryParse(aString, out a) && double.TryParse(xString, out x)))
                    {
                        Console.WriteLine("Недопустимые значения входных параметров: \n1)a и x - вещетвенные числа\n2)a != -x");
                        Console.Write(@"Введите a: ");
                        aString = Console.ReadLine();
                        Console.Write(@"Введите x: ");
                        xString = Console.ReadLine();
                    };
                    Console.WriteLine(@"Значение функции: " + Math.Log(Math.Abs(x + a)) / (1 + x * x));
                    int count = int.Parse(args[0]);
                    count--;
                    if (count > 0)
                    {
                        System.Threading.Thread.Sleep(1000);
                        ProcessStartInfo psi = new ProcessStartInfo(@"Function.exe")
                        {
                            UseShellExecute = true,
                            CreateNoWindow = true,
                            Arguments = count.ToString()
                        };
                        Process function = Process.Start(psi);
                    }
                }
                finishProgram = ReadResponse("Завершить работу? ", new string[] { YES, NO });
            } while (finishProgram.Equals(NO));
        }


        private static string ReadResponse(string message, string[] allowedResponses)
        {
            Console.WriteLine(message);
            string response = Console.ReadLine();
            while (!allowedResponses.Contains(response))
            {
                Console.Write(@"Неверный формат ввода. Допустимы ответы: ");
                foreach (var resp in allowedResponses)
                    Console.Write(resp + " ");
                Console.WriteLine();
                Console.WriteLine(message);
                response = Console.ReadLine();
            }
            return response;
        }
    }
}

