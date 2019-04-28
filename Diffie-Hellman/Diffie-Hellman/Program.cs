using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Diffie_Hellman
{
    class Program
    {
        class LongInt
        {
            private List<int> _value = new List<int>();
            private int _base = 4;
            const int MY_BASE = 10000;

            public LongInt(string str)
            {
                int temp = 0;
                int value = 0;

                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if (temp == this._base)
                    {
                        this._value.Add(value);
                        value = int.Parse(str[i].ToString());
                        temp = 1;
                    }
                    else
                    {
                        value += (int)Math.Pow(10, temp) * int.Parse(str[i].ToString());
                        temp += 1;
                    }
                }
                if (temp < this._base)
                    this._value.Add(value);
            }

            public LongInt(List<int> value)
            {
                this._value = value;
            }

            public static LongInt operator +(LongInt l1, LongInt l2)
            {
                int k = 0;
                LongInt result = new LongInt(new List<int>());

                int max = Math.Max(l1._value.Count, l2._value.Count);
                for (int i = 0; i < max; i ++)
                {
                    int a = (l1._value.Count > i)? l1._value[i] : 0;
                    int b = (l2._value.Count > i)? l2._value[i] : 0;
                    
                    result._value.Add(a + b + k);
                    if (result._value[result._value.Count - 1] > MY_BASE)
                    {
                        result._value[result._value.Count - 1] -= MY_BASE;
                        k = 1;
                    }
                    else
                    {
                        k = 0;
                    }
                }
                if (k == 1)
                    result._value.Add(k);

                return result;
            }

            public static LongInt operator -(LongInt l1, LongInt l2)
            {
                int k = 0;
                List<int> result = new List<int>();

                int max = Math.Max(l1._value.Count, l2._value.Count);
                for (int i = 0; i < max; i++)
                {
                    int a = (l1._value.Count > i) ? l1._value[i] : 0;
                    int b = (l2._value.Count > i) ? l2._value[i] : 0;

                    result.Add(a - b - k);
                    if (result[i] < 0)
                    {
                        result[i] += MY_BASE;
                        k = 1;
                    }
                    else
                    {
                        k = 0;
                    }
                }

                while (result.Count > 0 && result[result.Count - 1] == 0)
                {
                    result.RemoveAt(result.Count - 1);
                }

                return new LongInt(result);
            }

            public static LongInt operator *(LongInt l, int value)
            {
                if (value >= MY_BASE)
                    throw new Exception("This value is too big.");

                int k = 0;
                List<int> result = new List<int>();
                for (int i = 0; i < l._value.Count; i++)
                {
                    long temp = (l._value[i] * value + k);
                    result.Add((int)(temp % MY_BASE));
                    k = (int)(temp / MY_BASE);
                }
                if (k != 0)
                    result.Add(k);

                return new LongInt(result);
            }

            public static LongInt operator *(LongInt l1, LongInt l2)
            {
                LongInt result = new LongInt(new List<int>());
                for (int i = 0; i < l1._value.Count; i ++)
                {
                    LongInt temp = l2 * l1._value[i];
                    for (int j = 0; j < i; j++)
                    {
                        temp._value.Insert(0, 0);
                    }
                    result += temp;
                }
                return result;
            }

            public static bool operator >(LongInt l1, LongInt l2)
            {
                bool ans = true;

                if (l1._value.Count == l2._value.Count)
                {
                    for (int i = 0; i < Math.Max(l1._value.Count, l2._value.Count); i++)
                    {
                        if (l1._value[i] > l2._value[i])
                        {
                            ans = true;
                        }
                        else if (l1._value[i] < l2._value[i])
                        {
                            ans = false;
                        }
                    }
                }
                else
                {
                    if (l1._value.Count > l2._value.Count)
                    {
                        return true;
                    }
                    else if (l1._value.Count < l2._value.Count)
                    {
                        return false;
                    }
                }

                return ans;
            }

            public static bool operator <(LongInt l1, LongInt l2)
            {
                return (l2 > l1);
            }

            public static LongInt Pow(LongInt x, LongInt y)
            {
                LongInt i = new LongInt("1");
                LongInt result = new LongInt(x._value);

                while (i < y)
                {
                    result *= x;
                    i += new LongInt("1");
                }

                return result;
            }

            public static LongInt operator %(LongInt l1, LongInt l2)
            {
                LongInt result = new LongInt(l1._value);

                if (l1 < l2)
                {
                    return l1;
                }
                else
                {
                    while (l2 < result)
                    {
                        result -= l2;
                    }
                }

                return result;
            }

            public void Print()
            {
                Console.WriteLine(this.ToString());
            }

            public override string ToString()
            {
                string result = "";
                result += this._value[_value.Count - 1].ToString();

                for (int i = this._value.Count - 2; i >= 0; i--)
                {
                    string temp = this._value[i].ToString();
                    int zeroCount = this._base - temp.Length;
                    for (int j = 1; j <= zeroCount; j++)
                    {
                        result += "0";
                    }
                    result += temp;
                }

                return result;
            }
        }

        //public static BigInteger Sqrt(BigInteger n)
        //{
        //    if (n == 0) return 0;
        //    if (n > 0)
        //    {
        //        int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
        //        BigInteger root = BigInteger.One << (bitLength / 2);

        //        while (!isSqrt(n, root))
        //        {
        //            root += n / root;
        //            root /= 2;
        //        }

        //        return root;
        //    }

        //    throw new ArithmeticException("NaN");
        //}

        //private static Boolean isSqrt(BigInteger n, BigInteger root)
        //{
        //    BigInteger lowerBound = root * root;
        //    BigInteger upperBound = (root + 1) * (root + 1);

        //    return (n >= lowerBound && n < upperBound);
        //}

        //public static bool IsPrime(BigInteger n)
        //{
        //    for (BigInteger i = 2; i < Sqrt(n); i++)
        //    {
        //        if (n % i == 0)
        //            return false;
        //    }
        //    return true;
        //}

        static void Main(string[] args)
        {
            BigInteger p;
            BigInteger g;
            BigInteger a;
            BigInteger b;

            Console.WriteLine("Diffie-Hellman Simulator\n");
            Console.WriteLine("p - public modulus(must be prime); g - public base(must be primitive root modulo p); a - private Alice's key; b - private Bob's key\n");

            Console.WriteLine("1) Input p and g values:");
            while (true)
            {
                try
                {
                    Console.Write("    p = ");
                    p = BigInteger.Parse(Console.ReadLine());
                     break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Incorrect input.", e);

                    continue;
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("    g = ");
                    g = BigInteger.Parse(Console.ReadLine());
                    Console.WriteLine();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Incorrect input.", e);
                    continue;
                }
            }

            Console.WriteLine("2) Input a and b privite keys:");
            while (true)
            {
                try
                {
                    Console.Write("    Alice's privite key, a = ");
                    a = BigInteger.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Incorrect input.", e);
                    continue;
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("    Bob's privite key, b = ");
                    b = BigInteger.Parse(Console.ReadLine());
                    Console.WriteLine();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Incorrect input.", e);
                    continue;
                }
            }

            Console.WriteLine("3) First calculation values:\n    Alice have got A = {0}\n    Bob have got B = {1}\n", BigInteger.ModPow(g, a, p), BigInteger.ModPow(g, b, p));

            Console.WriteLine("4) Secret key is A^b mod p = B^a mod p = {0}", BigInteger.ModPow(BigInteger.ModPow(g, a, p), b, p));

            Console.ReadKey();
        }
    }
}
