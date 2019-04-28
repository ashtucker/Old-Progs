using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astask
{
    class Program
    {
        static string[] R = new string[10];

        static string[] alphabet = new string[26];

        static string adder;

        static string prevOperation;

        //сумматор

        static string Adder
        {
            set
            {
                adder = value;
            }

            get
            {
                return adder;
            }
        }

        static string[] Alphabet
        {
            set
            {
                alphabet = value;
            }

            get
            {
                return alphabet;
            }

        }

        //операнды

        static void L(string Operand)
        {
            Adder = Operand;

        }

        static void A(string Operand)
        {
            Adder = Adder + "+" + Operand;
        }

        static void S(string Operand)
        {
            Adder = Adder + '-' + Operand;
        }

        static void M(string Operand)
        {
            if (Operand.Count() == 1) //добавление необходимых скобок при умножении
            {
                if ((prevOperation == "A") || (prevOperation == "S"))
                {
                    Adder = "(" + Adder + ")" + '*' + Operand;
                }

                else
                {
                    Adder = Adder + '*' + Operand;
                }
            }

            else
            {
                if ((prevOperation == "A") || (prevOperation != "A"))
                {
                    Adder = "(" + Adder + ")" + '*' + "(" + Operand + ")";
                }

                else
                {
                    Adder = Adder + '*' + "(" + Operand + ")";
                }
            }
        }

        static void D(string Operand)
        {
            if (Operand.Count() == 1) //добавление необходимых скобок при делении
            {
                if (Adder.Count() != 1)
                {
                    Adder = "(" + Adder + ")" + '/' + Operand;
                }

                else
                {
                    Adder = Adder + '/' + Operand;
                }
            }

            else
            {
                if (Adder.Count() != 1)
                {
                    Adder = "(" + Adder + ")" + '/' + "(" + Operand + ")";
                }

                else
                {
                    Adder = Adder + '/' + "(" + Operand + ")";
                }
            }
        }

        static void N()
        {

            for (int i = 0; i < Adder.Length - 1; i++)
            {
                if ((i == 0) && (CompareWithAlphabet(Adder[i])))

                {
                    if (i == '-')
                    {
                        Adder = Adder.Remove(i, 1);
                    }

                    else
                    {
                        Adder = Adder.Insert((i), "-");
                    }

                    continue;
                }

                if (CompareWithAlphabet(Adder[i + 1]))

                {


                    if (Adder[i] != '-')
                    {

                        Adder = Adder.Insert((i + 1), "-");
                        i++;

                    }

                    else
                    {

                        Adder = Adder.Remove(i, 1);
                        Adder = Adder.Insert(i, "+");

                    }
                }
            }

            for (int i = 1; i < Adder.Length - 1; i++)
            {
                if ((Adder[i] == '-') && (Adder[i + 1] == '+'))
                {
                    Adder = Adder.Remove((i + 1), 1);
                }

                if ((Adder[i] == '+') && (Adder[i + 1] == '-'))
                {
                    Adder = Adder.Remove(i, 1);
                }

                if ((Adder[i] == '-') && ((Adder[i - 1] == '/') || (Adder[i - 1] == '*')))
                {
                    Adder = Adder.Insert(i, "(");
                    Adder = Adder.Insert(i + 3, ")");
                    i++;
                    i++;
                }
            }

        }

        static void ST(ref string Operand)
        {
            Operand = Adder;
        }


        static void RecognAlphabet(string Operand, ref string Operand0)
        {
            int CodeOfA = 65;

            int operand = (int)Convert.ToChar(Operand);

            Operand0 = Alphabet[operand - CodeOfA];

        }

        static void RecognReg(string Operand, ref string Operand1) //регистры
        {

            int i = Convert.ToInt16(Operand[1]);

            i = i - 48;

            Operand1 = R[i];

        }

        static bool ComparewithReg(string Operand) 
        {
            bool temp = false;

            if ((Operand[0] == 'R') && (Operand.Count() != 1))
            {
                temp = true;
            }

            return temp;

        }

        static bool CompareWithAlphabet(char Operand) 
        {
            int operand = (int)Operand;

            if ((operand >= 65) && (operand <= 90))
            {
                return true;
            }

            else
            {
                return false;
            }
        }


        static void ChangeRegister(string Operand, string WhatToReplace)
        {
            int CodeofZero = 48;

            int i = Convert.ToInt16(Operand[1]);

            i = i - CodeofZero;

            R[i] = WhatToReplace;
        }

        static void ChangeAlphabet(string Operand, string WhatToReplace)
        {
            int CodeOfA = 65;

            int operand = (int)Convert.ToChar(Operand);

            operand -= CodeOfA;

            Alphabet[operand] = WhatToReplace;


        }

        static void ChangeOperand(string Operand, string WhatToReplace)
        {
            if (!ComparewithReg(Operand))
            {
                ChangeAlphabet(Operand, WhatToReplace);
            }

            else
            {
                ChangeRegister(Operand, WhatToReplace);
            }
        }


        static void Recognition(string line)
        {

            string[] Rec = line.Split();

            try
            {
                string Operand2 = Rec[1];


                if (ComparewithReg(Rec[1]))
                {
                    RecognReg(Rec[1], ref Operand2);
                }

                else
                {
                    RecognAlphabet(Rec[1], ref Operand2);

                }

                switch (Rec[0])
                {
                    case "L":
                        {

                            L(Operand2);

                            prevOperation = "L";

                            break;
                        }

                    case "A":
                        {
                            A(Operand2);

                            prevOperation = "A";

                            break;
                        }

                    case "S":
                        {
                            S(Operand2);

                            prevOperation = "S";

                            break;
                        }

                    case "M":
                        {

                            M(Operand2);

                            prevOperation = "M";

                            break;
                        }

                    case "D":
                        {

                            D(Operand2);

                            prevOperation = "D";

                            break;
                        }

                    case "ST":
                        {

                            ST(ref Operand2);

                            ChangeOperand(Rec[1], Operand2);

                            break;
                        }
                }
            }

            catch (IndexOutOfRangeException)
            {
                N();
            }
        }

        static void CheckMemory()
        {
            int CodeOfA = 65;

            for (int i = 0; i < Alphabet.Length; i++)
            {
                if ((Alphabet[i].Length != 1) || ((int)Alphabet[i][0] != (i + CodeOfA)))
                {
                    Console.WriteLine(Convert.ToChar(i + CodeOfA) + "= " + Alphabet[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            int CodeOfA = 65;

            for (int i = 0; i < Alphabet.Length; i++)
            {
                Alphabet[i] = Convert.ToString(Convert.ToChar(i + CodeOfA));
            }

            string Operation = Console.ReadLine();

            while (Operation != "")
            {

                Recognition(Operation);

                Operation = Console.ReadLine();

            }

            CheckMemory();

            Console.ReadLine();
        }

    }
}
