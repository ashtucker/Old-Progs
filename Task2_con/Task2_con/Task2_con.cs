using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_con
{
    class Program
    {
        const string YES = @"Да";
        const string NO = @"Нет";
        private static string[] allowedResponsesYesNo = new string[] { YES, NO };

        static void Main(string[] args)
        {
            Console.WriteLine(
          @"Практическая Работа №2" + "\n" +
          "Макетное представление диалогового взаимодействия на основе конструкции" + "\n" +
          @"“Последовательная интерпетация элементов”" + "\n\n" +
          @"Выполнила студентка 2 курса группы 09-411 Рябова Дарья" + "\n");

            if (ReadResponse("Начать работу?", allowedResponsesYesNo).Equals(YES))
            {
                TwoArgsFunc func1 = new TwoArgsFunc(
                    (double x, double a) => { return Math.Cos(a) * Math.Cos(a) + Math.Log(Math.Abs((1 - x) / (1 + x))); },
                    @"Функция №1:" + "\n" + @"y = cos^2(a) + ln|(1-x)/(1+x)|",
                    (double x, double a) => { return (x != 1) && (x != -1); });
                func1.CalculateConsole();

                if (ReadResponse(@"Продолжить работу?", allowedResponsesYesNo).Equals(YES))
                {
                    TwoArgsFunc func2 = new TwoArgsFunc(
                        (double x, double a) => { return Math.Sin(x) / (Math.Cos(x) * Math.Cos(x) + a); },
                        @"Функция №2:" + "\n" + @"sin(x)/(cos^2(x) + a)",
                        (double x, double a) => { return (Math.Cos(x) * Math.Cos(x)) != (-a); });
                    func2.CalculateConsole();

                    if (ReadResponse(@"Продолжить работу?", allowedResponsesYesNo).Equals(YES))
                    {
                        TwoArgsFunc func3 = new TwoArgsFunc(
                            (double x, double a) => { return Math.Log(Math.Abs((a - x) / (a + x))); },
                            @"Функция №3:" + "\n" + @"ln|(a - x)/(a + x)|",
                            (double x, double a) => { return (a != -x) && (a != x); });
                        func3.CalculateConsole();

                        if (ReadResponse(@"Продолжить работу?", allowedResponsesYesNo).Equals(YES))
                        {
                            TwoArgsFunc func4 = new TwoArgsFunc(
                                (double x, double a) => { return Math.Sin(x * x) / Math.Log(Math.Abs(a + x)); },
                                @"Завершающая функция №4:" + "\n" + @"sin(x^2)/ln|a + x|",
                                (double x, double a) => { return a != -x; });
                            func4.CalculateConsole();
                        }
                    }
                }
            }

            Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
            Console.ReadKey();
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
