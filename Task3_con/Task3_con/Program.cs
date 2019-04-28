using System;
using System.Linq;
namespace PHMI_Task3_Console
{
    class Program
    {
        const string YES = @"Да";
        const string NO = @"Нет";
        static void Main(string[] args)
        {
            Console.WriteLine(
          @"Практическая hабота №3" + "\n" +
          "Макетное представление диалогового взаимодействия на основе конструкции" + "\n" +
          @"“If Then Else”" + "\n\n" +
          @"Выполнила студентка 2 курса группы 09-411 Рябова Дарья" + "\n");

            string finishProgram;
            do
            {
                string startResponse = ReadResponse("Начать работу?", new string[] { YES, NO });
                if (startResponse.Equals(YES))
                {
                    string groupResponse = ReadResponse("Какую группу из представленных выполнить?\n" + @"1. y = ln|x + a|/(1 + x^2)" + "\n" + @"2. y = ln(|a - x|/|a + x|)",
                                                            new string[] { @"1", @"2" });
                    if (groupResponse.Equals(@"1"))
                    {
                        string resposeConfirm = ReadResponse("Выполнить функцию группы 1?", new string[] { YES, NO });
                        if (resposeConfirm.Equals(YES))
                        {
                            double a, x;
                            string aString, xString;
                            Console.Write(@"Введите a: ");
                            aString = Console.ReadLine();
                            Console.Write(@"Введите x: ");
                            xString = Console.ReadLine();
                            while (!(double.TryParse(aString, out a) && double.TryParse(xString, out x)) || a == -x)
                            {
                                Console.WriteLine("Недопустимые значения входных параметров: \n1)a и x - вещетвенные числа\n2)a != -x");
                                Console.Write(@"Введите a: ");
                                aString = Console.ReadLine();
                                Console.Write(@"Введите x: ");
                                xString = Console.ReadLine();
                            };
                            Console.WriteLine(@"Значение функци: " + Math.Log(Math.Abs(x + a)) / (1 + x * x));
                        }
                    }
                    else
                    {
                        string resposeConfirm = ReadResponse("Выполнить функцию группы 2?", new string[] { YES, NO });
                        if (resposeConfirm.Equals(YES))
                        {
                            double a, x;
                            string aString, xString;
                            Console.Write(@"Введите a: ");
                            aString = Console.ReadLine();
                            Console.Write(@"Введите x: ");
                            xString = Console.ReadLine();
                            while (!(double.TryParse(aString, out a) && double.TryParse(xString, out x)) || a == x || a == -x)
                            {
                                Console.WriteLine("Недопустимые значения входных параметров: \n1)a и x - вещественные числа\n2)a != x\n3)a != -x");
                                Console.Write(@"Введите a: ");
                                aString = Console.ReadLine();
                                Console.Write(@"Введите x: ");
                                xString = Console.ReadLine();
                            };
                            Console.WriteLine(@"Значение функци: " + Math.Log(Math.Abs(a - x) / Math.Abs(a + x)));
                        }
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


