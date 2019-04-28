using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace task_1_Метод_Полларда
{
    class FirstStage
    {
        BigInteger _n;

        int _B;

        int _a;

        BigInteger _Mb = 1;

        List<BigInteger> Mb = new List<BigInteger>();

        List<int> SN = new List<int>();

        public BigInteger N
        {
            get
            {
                return this._n;
            }
        }

        public int B
        {
            get
            {
                return this._B;
            }
        }

        public BigInteger PowerAMB
        {
            get
            {
                return Remainder();
            }
        }

        public FirstStage(BigInteger n)
        {
            this._n = n;
        }

        private void InitializationB()
        {
            if (this._n > 9000)
            {
                this._B = 10;
            }

            else
                this._B = 6;
        }

        private void InitializationA()
        {
            Random r = new Random();

            this._a = r.Next(1000000000);
        }

        private void ChangeB()
        {
            this._B += 3;
        }

        private void InitializeSN(long edge)
        {
            SN.Clear();

            for (int i = 2; i < edge; i++)
            {
                SN.Add(i);
            }

        }

        private void Eratostene()
        {

            for (int i = 0; i < SN.Count; i++)
            {

                if (SN[i] != 0)
                {
                    for (int j = i + 1; j < SN.Count; j++)
                    {
                        if (SN[j] % SN[i] == 0)
                        {
                            SN[j] = 0;
                        }
                    }
                }
            }

        }

        private void RemoveZero()
        {
            for (int i = 0; i < SN.Count; i++)
            {
                if (SN[i] == 0)
                {
                    SN.RemoveAt(i);
                    i--;
                }
            }
        }

        private void SimpleNumbers(long edge)
        {
            InitializeSN(edge);

            Eratostene();

            RemoveZero();

        }

        private void CreateMassiveMb()
        {

            while (_Mb >= 1000)
            {
                Mb.Add(1000);

                _Mb -= 1000;
            }

            if (_Mb != 0)
            {
                Mb.Add(_Mb);
                _Mb = 0;

            }
            
        }

        private void FindMb()
        {
            double edge = 0;

            for (int i = 0; i < SN.Count; i++)
            {
                if (SN[i] < this._B)
                {
                    int j = 1;

                    while(Math.Pow(Convert.ToDouble(SN[i]), Convert.ToDouble(j)) < this._B)
                    {
                        edge = Math.Pow(Convert.ToDouble(SN[i]), Convert.ToDouble(j));

                        j++;
                    }

                    _Mb *= (BigInteger)edge;
                }
            }

            CreateMassiveMb();
        }

        private BigInteger Remainder()
        {
            BigInteger pow = 1;

            for (int i = 0; i < Mb.Count; i++)
            {
                for (int j = 0; j < Mb[i]; j++)
                {
                    pow = (pow * this._a) % this._n;
                }
            }
            
            return pow;
        }

        private BigInteger GCD(BigInteger a,BigInteger b)
        {
            BigInteger first;

            BigInteger second;

            if (a >= b)
            {
                first = a;

                second = b;
            }

            else
            {
                first = b;

                second = a;
            }

            BigInteger temp;

            do
            {
                temp = first % second;

                first = second;

                second = temp;

            }

            while (second != 0);

            return first;

        }

        public BigInteger Result()
        {
            InitializationB();

            InitializationA();

            SimpleNumbers(this._B);

            FindMb();

            BigInteger newa = Remainder() - 1;

            BigInteger result = 0;

            if (newa > 0)
            {
                result = GCD(newa, this._n);
            }

            return result;

        }

        public BigInteger TryFindResultAgain()
        {
            InitializationA();

            ChangeB();

            SimpleNumbers(this._B);

            FindMb();

            BigInteger newa = Remainder() - 1;

            BigInteger result = 0;

            if (newa > 0)
            {
                result = GCD(newa, this._n);
            }

            else
            {
                TryFindResultAgain();
            }
            return result;
        }
    }

    class SecondStage
    {
        BigInteger _n;

        int _B1;

        int _B2;

        BigInteger _b;

        BigInteger _Q;

        List<int> _q = new List<int>();

        int q;
 
       

        public void  Initialize(int B, BigInteger n, BigInteger b)
        {
            this._n = n;

            this._B1 = B;

            this._b = b;

            this._B2 = this._B1 * this._B1;

        }

        private void Initializeq()
        {
            _q.Clear();

            for (int i = 2; i < _B2; i++)
            {
                _q.Add(i);
            }

        }

        private void Eratostene()
        {

            for (int i = 0; i < _q.Count; i++)
            {

                if (_q[i] != 0)
                {
                    for (int j = i + 1; j < _q.Count; j++)
                    {
                        if (_q[j] % _q[i] == 0)
                        {
                            _q[j] = 0;
                        }
                    }
                }
            }

        }

        private void RemoveZero()
        {
            for (int i = 0; i < _q.Count; i++)
            {
                if (_q[i] == 0)
                {
                    _q.RemoveAt(i);
                    i--;
                }
            }
        }

        private void RemoveBeyondLimits()
        {
            for (int i = 0; i < _q.Count; i++)
            {
                if (_q[i] < _B1)
                {
                    _q[i] = 0;
                }
            }
        }

        public void SimpleNumbers()
        {
            Initializeq();

            Eratostene();

            RemoveBeyondLimits();

            RemoveZero();

            
        }

        private BigInteger GCD(BigInteger a, BigInteger b)
        {
            BigInteger first;

            BigInteger second;

            if (a >= b)
            {
                first = a;

                second = b;
            }

            else
            {
                first = b;

                second = a;
            }

            BigInteger temp;

            do
            {
                try
                {
                    temp = first % second;

                    first = second;

                    second = temp;
                }

                catch(DivideByZeroException)
                {
                    return 0;
                }

            }

            while (second != 0);

            return first;

        }

        private BigInteger Remainder(BigInteger power, BigInteger x)
        {
            BigInteger pow = 1;

            for (int i = 0; i < power; i++)
            {
                pow = (pow * x) % this._n;
            }

            return pow;
        }

        public BigInteger Result()
        {
            SimpleNumbers();

            this._Q = 1;

            BigInteger c;

            for (int i = 0; i < _q.Count; i++)
            {
                c = Remainder(this._q[i], this._b);

                BigInteger newc = c - 1;

                this._Q = GCD(newc, this._n);

                if ((this._Q != 1) && (this._Q != 0))
                {
                    return this._Q;
                }

            }

            return 0;
        }

    }

    class Program
    {
        static BigInteger FindDivider(BigInteger n)
        {

            FirstStage Fq = new FirstStage(n);

            SecondStage Sq = new SecondStage();

            BigInteger q = Fq.Result();
            
            if ((q != 0) && (q != -1)  && (q != 1))
            {

            }

            else
            {
                while ((q == 0) || (q == -1) || (q == 1))
                {

                    q = Fq.TryFindResultAgain();

                    if ((q == 0) || (q == -1) || (q == 1))
                    {
                        Sq.Initialize(Fq.B, n, Fq.PowerAMB);

                        q = Sq.Result();
                    }
                }

            }
         
            return q;
            
        }

        static bool Check(BigInteger n)
        {
            for (int i = 2; i < n; i++)
            {
                if ( n % i == 0)
                {
                    return true;
                }
            }

            return false;
        }
        static void Main(string[] args)
        {

            BigInteger n = BigInteger.Parse(Console.ReadLine());

            if (n < 1000000000)
            {
                if (Check(n))
                {
                    FindDivider(n);

                    if (FindDivider(n) != 0)
                    {
                        Console.WriteLine("Искомое q= " + FindDivider(n));
                    }

                    else
                    {
                        Console.WriteLine("Число может быть простым");
                    }
                }

                else
                {
                    Console.WriteLine("Это число простое");
                }
            }

            else
            {
                FindDivider(n);

                if (FindDivider(n) != 0)
                {
                    Console.WriteLine("Искомое q= " + FindDivider(n));
                }

                else
                {
                    Console.WriteLine("Число может быть простым");
                }
            }

            Console.ReadKey();

        }
    }
}
