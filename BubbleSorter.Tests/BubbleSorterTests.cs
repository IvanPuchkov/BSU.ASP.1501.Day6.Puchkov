using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BubbleSorter.Tests
{
    public class SumComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y) => x.Sum() - y.Sum();
    }

    public class MaxElementComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y) => x.Max() - y.Max();
    }

    public class MinElementComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y) => x.Min() - y.Min();
    }

    [TestFixture]
    public class BubbleSorterTests
    {
        private readonly int[][] _array = new[] {new[] {5, 4, 8}, new[] {-5, 6, 10},new[] {3,6,1}};

        public IEnumerable<TestCaseData> TestCaseDatasBubbleSorterInterfaceLock
        {
            get
            {
                yield return
                    new TestCaseData(new[] {new[] {3, 6, 1},  new[] {-5, 6, 10}, new[] { 5, 4, 8 }},
                        (BublleSorterInterfaceLock<int[]>.Compare)((x, y) => x.Sum() - y.Sum()));
                yield return
                    new TestCaseData(new[] {new[] {3, 6, 1}, new[] {5, 4, 8}, new[] { -5, 6, 10 }},
                        (BublleSorterInterfaceLock<int[]>.Compare)((x, y) => x.Max() - y.Max()));
                yield return
                    new TestCaseData(new[] { new[] { -5, 6, 10 }, new[] {3, 6, 1}, new[] { 5, 4, 8 } },
                        (BublleSorterInterfaceLock<int[]>.Compare) ((x, y) => x.Min() - y.Min()));
            }
        }

        public IEnumerable<TestCaseData> TestCaseDatasBubbleSorterDelegateLock
        {
            get
            {
                yield return
                    new TestCaseData(new[] {new[] {3, 6, 1}, new[] { -5, 6, 10 }, new[] {5, 4, 8}},
                        new SumComparer());
                yield return
                    new TestCaseData(new[] {new[] {3, 6, 1}, new[] { 5, 4, 8 }, new[] {-5, 6, 10}},
                        new MaxElementComparer());
                yield return
                    new TestCaseData(new[] { new[] { -5, 6, 10 }, new[] {3, 6, 1}, new[] { 5, 4, 8 }},
                        new MinElementComparer());
            }
        }

        [Test, TestCaseSource(nameof(TestCaseDatasBubbleSorterDelegateLock))]
        public void BubbleSorterDelegateLockTests(int[][] sortedArray, IComparer<int[]> comparer)
        {
            var array =(int[][]) _array.Clone();
            var bubbleSorter=new BubbleSorterDelegateLock<int[]>();
            bubbleSorter.Sort(array,comparer);
            Assert.AreEqual(sortedArray,array);
        }

        [Test, TestCaseSource(nameof(TestCaseDatasBubbleSorterInterfaceLock))]
        public void BubbleSorterInterfaceLockTests(int[][] sortedArray, BublleSorterInterfaceLock<int[]>.Compare compare )
        {
            var array = (int[][])_array.Clone();
            var bubbleSorter = new BublleSorterInterfaceLock<int[]>();
            bubbleSorter.Sort(array, compare);
            Assert.AreEqual(sortedArray, array);
        }
    }
}

