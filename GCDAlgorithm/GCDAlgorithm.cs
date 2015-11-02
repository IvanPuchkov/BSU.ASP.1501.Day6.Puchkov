using System;
using System.Diagnostics;
using System.Linq;


namespace GCDAlgorithm
{
    public static class GcdAlgorithm
    {
        private delegate int GcdAlgorithmDelegate(int a, int b);

        private static int CalculateEucledeanGcd(int a, int b)
        {
            if ((a == 0) || (b == 0))
            {
                return Math.Max(a, b);
            }
            int output = a > b ? CalculateEucledeanGcd(a % b, b) : CalculateEucledeanGcd(a, b % a);
            return output;
        }

        public static int CalculateSteinGcd(int a, int b)
        {
            if ((a == 0) && (b == 0))
                return 0;
            if ((a == 0) || (b == 0))
                return Math.Max(a, b);
            if ((a % 2 == 0) && (b % 2 == 0))
                return CalculateSteinGcd(a / 2, b / 2) * 2;
            if (a % 2 == 0)
                return CalculateSteinGcd(a / 2, b);
            if (b % 2 == 0)
                return CalculateSteinGcd(a, b / 2);
            int greatest = Math.Max(a, b);
            int lowest = Math.Min(a, b);
            return CalculateSteinGcd((greatest - lowest) / 2, lowest);
        }

        private static int Calculate(GcdAlgorithmDelegate algorithm,int a, int b)
        {
            if ((a == 0) || (b == 0))
                throw new ArgumentException("None of numbers should be equal to zero");
            return algorithm(a, b);
        }

        private static int Calculate(GcdAlgorithmDelegate algorithm, int a, int b, int c)
            => Calculate(algorithm, a, Calculate(algorithm, b, c));

        private static int Calculate(GcdAlgorithmDelegate algorithm, params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();
            if (numbers.Count() < 2)
                throw new ArgumentException();
            int output = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                output = Calculate(algorithm,output, numbers[i]);
            }
            return output;
        }

        private static int Calculate(GcdAlgorithmDelegate algorithm, out long time, int a, int b)
        {
            Stopwatch sw=new Stopwatch();
            sw.Start();
            int result=Calculate(algorithm, a, b);
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return result;
        }

        private static int Calculate(GcdAlgorithmDelegate algorithm, out long time, int a, int b, int c)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int result = Calculate(algorithm, a, b, c);
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return result;
        }

        private static int Calculate(GcdAlgorithmDelegate algorithm, out long time, params int[] numbers)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int result = Calculate(algorithm, numbers);
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return result;
        }

        public static int EucledeanGcd(int a, int b) => Calculate(CalculateEucledeanGcd, a, b);

        public static int EucledeanGcd(int a, int b, int c) => Calculate(CalculateEucledeanGcd, a, b, c);

        public static int EucledeanGcd(params int[] numbers) => Calculate(CalculateEucledeanGcd, numbers);

        public static int EucledeanGcd(out long time, int a, int b) => Calculate(CalculateEucledeanGcd, out time, a, b);

        public static int EucledeanGcd(out long time, int a, int b, int c)
            => Calculate(CalculateEucledeanGcd, out time, a, b, c);

        public static int EucledeanGcd(out long time, params int[] numbers)
            => Calculate(CalculateEucledeanGcd, out time, numbers);

        public static int SteinGcd(int a, int b) => Calculate(CalculateSteinGcd, a, b);

        public static int SteinGcd(int a, int b, int c) => Calculate(CalculateSteinGcd, a, b, c);

        public static int SteinGcd(params int[] numbers) => Calculate(CalculateSteinGcd, numbers);

        public static int SteinGcd(out long time, int a, int b) => Calculate(CalculateSteinGcd, out time, a, b);

        public static int CalculateSteinGcd(out long time, int a, int b, int c)
            => Calculate(CalculateSteinGcd, out time, a, b, c);

        public static int SteinGcd(out long time, params int[] numbers) => Calculate(SteinGcd, out time, numbers);

    }
}

    
