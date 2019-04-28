using System;
using System.Linq;
using System.Diagnostics;

namespace PHMI_Task4
{
    class Program
    {
        const string YES = @"Да";
        const string NO = @"Нет";
        static void Main(string[] args)
        {
            Console.WriteLine(@"Практическая работа №4" + "\n" + @"Макетное представление диалогового взаимодействия на основе конструкции" +
                "\n" + "“DO WHILE”" + "\n" + "\n" + @"Выполнила студентка 2 курса группы 09-411 Рябова Дарья" + "\n\n" + @"Функция: Log|x + a|/(1 + x * x)");

            string finishProgram;
            do
            {
                string startResponse = ReadResponse("Начать работу?", new string[] { YES, NO });
                if (startResponse.Equals(YES))
                {
                    int count = 0;
                    Console.WriteLine(@"Сколько раз выполнить функцию?");
                    while (!int.TryParse(Console.ReadLine(), out count))
                    {
                        Console.WriteLine(@"Допустимы только целые числа");
                        Console.WriteLine(@"Сколько раз выполнить функцию?");
                    }
                    ProcessStartInfo psi = new ProcessStartInfo(@"Function.exe")
                    {
                        UseShellExecute = true,
                        CreateNoWindow = true,
                        Arguments = count.ToString()
                    };
                    Process function = Process.Start(psi);
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

