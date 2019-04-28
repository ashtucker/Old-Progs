using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_con
{
    class TwoArgsFunc
    {
        Func<double, double, double> func;
        Func<double, double, bool> argsValidator;
        private string stringFunc;

        public TwoArgsFunc(Func<double, double, double> func, string stringFunc, Func<double, double, bool> argsValidator)
        {
            this.func = func;
            this.argsValidator = argsValidator;
            this.stringFunc = stringFunc;
        }

        public bool TryCalculate(double x, double a, out double result)
        {
            if (argsValidator(x, a))
            {
                result = func(x, a);
                return true;
            }
            else
            {
                result = 0;
                return false;
            }
        }

        public override string ToString()
        {
            return stringFunc;
        }

        public void CalculateConsole()
        {
            Console.WriteLine(@"Выполняется " + this.ToString());

            double a, x;
            string aString, xString;
            Console.Write(@"Введите a: ");
            aString = Console.ReadLine();
            Console.Write(@"Введите x: ");
            xString = Console.ReadLine();

            double y;
            while (!(double.TryParse(aString, out a) && double.TryParse(xString, out x)) || !this.TryCalculate(x, a, out y))
            {
                Console.WriteLine("Недопустимые значения входных параметров.");
                Console.Write(@"Введите a: ");
                aString = Console.ReadLine();
                Console.Write(@"Введите x: ");
                xString = Console.ReadLine();
            };

            Console.WriteLine(@"Результат вычисления: " + y);
        }
    }
}
