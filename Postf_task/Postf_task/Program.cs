using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;


namespace Postf_task
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


            Console.WriteLine("Введите выражение в инфиксной записи");


            // Входная строка
            string expression = Console.ReadLine();


            // Создание пустого стека для хранения операторов
            Stack<char> operatorStack = new Stack<char>();


            // Создание пустого списка для вывода
            List<char> postfixList = new List<char>();


            // Переменная в которой хранится первый элемент стека 
            char first;


            // Переменная - статус
            int status = 2;


            int i = 0;


            int k = 0;


            string operand;


            expression = expression + '$';


            // Алгоритм сортировочной станции Дейкстры
            while (status == 2)
            {
                // Получение элемента на вершине стека
                if (operatorStack.Count != 0) first = operatorStack.First();
                else first = '\0';


                // Проверка является ли элемент числом
                if (i != (expression.Length - 1))
                {
                    if (Char.IsDigit(expression[i]) | (expression[i] == '.') | ((expression[i] == '-') & (Char.IsDigit(expression[i + 1]))))
                    {
                        if ((expression[i] == '-') & (Char.IsDigit(expression[i + 1])))
                        {
                            postfixList.Add(expression[i]);
                            i++;
                        }


                        while (Char.IsDigit(expression[i]) | (expression[i] == '.'))
                        {
                            postfixList.Add(expression[i]);
                            i++;
                            if (i == expression.Length)
                            {
                                i--;
                                break;
                            }
                        }
                        postfixList.Add(' ');
                    }
                }


                // Проверка является ли элемент операндом
                if (Char.IsLetter(expression[i]))
                {
                    postfixList.Add(expression[i]);
                    postfixList.Add(' ');
                    i++;
                }


                if (expression[i] == ' ')
                    i++;


                // Если на стрелке + или -
                else if (expression[i] == '+' || expression[i] == '-')
                {
                    if (first == '\0' || first == '(')
                    {
                        operatorStack.Push(expression[i]);
                        i++;
                    }


                    else if (first == '+' || first == '-' || first == '*' || first == '/')
                    {
                        postfixList.Add(operatorStack.Pop());
                        postfixList.Add(' ');
                    }
                }


                // Если на стрелке * или /
                else if (expression[i] == '*' || expression[i] == '/')
                {
                    if (first == '\0' || first == '(' || first == '+' || first == '-')
                    {
                        operatorStack.Push(expression[i]);
                        i++;
                    }
                    else if (first == '*' || first == '/')
                    {
                        postfixList.Add(operatorStack.Pop());
                        postfixList.Add(' ');
                    }
                }


                // Если на стрелке открывающая скобка, то добавляем её в стек
                else if (expression[i] == '(')
                {
                    operatorStack.Push(expression[i]);
                    i++;
                }


                // Если на стрелке закрывающая скобка
                else if (expression[i] == ')')
                {
                    // Если на стрелке закрывающая скобка, а в стеке нет элементов - изменяем стутус на 0 - ошибка
                    if (first == '\0') status = 0;
                    else if (first == '+' || first == '-' || first == '*' || first == '/')
                    {
                        postfixList.Add(operatorStack.Pop());
                        postfixList.Add(' ');
                    }
                    else if (first == '(')
                    {
                        operatorStack.Pop();
                        i++;
                    }
                }


                // Если последний элемент
                else if (expression[i] == '$')
                {
                    if (first == '\0') status = 1;
                    else if (first == '+' || first == '-' || first == '*' || first == '/')
                    {
                        postfixList.Add(operatorStack.Pop());
                        postfixList.Add(' ');
                    }
                    else if (first == '(') status = 0; // Если на стрелке последний вагон, а в стеке есть открывающая скобка - ошибка
                }
                else status = 0; // Неизвестный символ
            }


            i = 0;

/////////////////////////
            Console.WriteLine();


            while (i < postfixList.Count)
            {
                Console.Write(postfixList[i]);
                i++;
            }


            Console.WriteLine();
            Console.WriteLine();




            for (i = 0; i < postfixList.Count; i++)
            {
                // Проверка является ли элемент операндом
                if (Char.IsLetter(postfixList[i]))
                {
                    if (k == 0)
                    {
                        Console.WriteLine("Введите значения операнд");
                        k = 1;
                    }


                    Console.Write(postfixList[i] + " = ");
                    operand = Convert.ToString(Console.ReadLine());


                    Console.WriteLine();                  

                    postfixList.RemoveAt(i);


                    for (int l = operand.Length; l > 0; l--)
                    {
                        postfixList.Insert(i, operand[l - 1]);                        
                    }


                    operand.Remove(0, operand.Length);
                    i++;
                }
            }
            

            // Стек для хранения чисел
            Stack<double> stackDigit = new Stack<double>();


            double var1, var2 = 0;


            StringBuilder number = new StringBuilder();
            int statusNumber = 0;
            i = 0;


            for (i = 0; i < postfixList.Count; i++)
            {
                if (i != (postfixList.Count - 1))
                {
                    if (Char.IsDigit(postfixList[i]) | (postfixList[i] == '.') | ((postfixList[i] == '-') & (Char.IsDigit(postfixList[i + 1]))))
                    {
                        if ((postfixList[i] == '-') & (Char.IsDigit(postfixList[i + 1])))
                        {
                            number.AppendFormat(Convert.ToString(postfixList[i]));
                            i++;
                            statusNumber = 1;
                        }


                        while (Char.IsDigit(postfixList[i]) | (postfixList[i] == '.'))
                        {
                            number.AppendFormat(Convert.ToString(postfixList[i]));
                            i++;
                            statusNumber = 1;
                            if (i == postfixList.Count)
                            {
                                i--;
                                break;
                            }
                        }
                    }
                }


                if (statusNumber == 1)
                {
                    stackDigit.Push(Convert.ToDouble(number.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                }
                else if (postfixList[i] == '+') stackDigit.Push(stackDigit.Pop() + stackDigit.Pop());
                else if (postfixList[i] == '-')
                {
                    var2 = stackDigit.Pop();
                    var1 = stackDigit.Pop();
                    stackDigit.Push(var1 - var2);
                }
                else if (postfixList[i] == '*') stackDigit.Push(stackDigit.Pop() * stackDigit.Pop());
                else if (postfixList[i] == '/')
                {
                    var2 = stackDigit.Pop();
                    var1 = stackDigit.Pop();
                    stackDigit.Push(var1 / var2);
                }


                statusNumber = 0;
                number.Remove(0, number.Length);
            }
            Console.WriteLine(stackDigit.Pop());

            Console.WriteLine("Для продолжения нажмите любую клавишу...");

            Console.ReadLine();
        }
    }
}