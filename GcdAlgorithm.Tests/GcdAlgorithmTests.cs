using NUnit.Framework;

namespace GcdAlgorithm.Tests
{
    [TestFixture]
    public class GcdAlgorithmTests
    {
        [TestCase(10, 5, Result = 5)]
        [TestCase(5, 1, Result = 1)]
        [TestCase(964, 592, Result = 4)]
        public int EuclideanAlgorithmTests_Two_Numbers(int a, int b)=>
            GCDAlgorithm.GcdAlgorithm.EucledeanGcd(a, b);
        

        [TestCase(964, 592, 400, Result = 4)]
        [TestCase(100, 5, 20, Result = 5)]
        public int EuclideanAlgorithmTests_Three_Numbers(int a, int b, int c)
            => GCDAlgorithm.GcdAlgorithm.EucledeanGcd(a, b, c);
        


        [TestCase(10, 20, 30, 40, Result = 10)]
        public int EuclideanAlgorithmTests_Multiple_Numbers(params int[] numbers) =>
            GCDAlgorithm.GcdAlgorithm.EucledeanGcd(numbers);
        


        [TestCase(10, 5, Result = 5)]
        [TestCase(5, 1, Result = 1)]
        [TestCase(964, 592, Result = 4)]
        public int SteinAlgorithmTests_Two_Numbers(int a, int b) => GCDAlgorithm.GcdAlgorithm.SteinGcd(a, b);


        [TestCase(964, 592, 400, Result = 4)]
        [TestCase(100, 5, 20, Result = 5)]
        public int SteinAlgorithmTests_Three_Numbers(int a, int b, int c) => GCDAlgorithm.GcdAlgorithm.SteinGcd(a, b, c);



        [TestCase(10, 20, 30, 40, Result = 10)]
        public int SteinAlgorithmTests_Multiple_Numbers(params int[] numbers)
            => GCDAlgorithm.GcdAlgorithm.SteinGcd(numbers);

    }
}
