using System;


namespace BubbleSorter
{
    public class BublleSorterInterfaceLock<T>
    {
        public delegate int Compare(T x, T y);

        static void Swap(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        public void Sort(T[] array, IComparer<T> comparer)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (comparer == null)
            {
                if (!typeof(T).IsAssignableFrom(typeof(IComparable)))
                    throw new ArgumentNullException(nameof(comparer));
            }
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length-1; j++)
                {
                    if (comparer != null)
                    {
                        if (comparer.Compare(array[j], array[j + 1]) > 0)
                            Swap(ref array[j], ref array[j + 1]);
                    }
                    else
                    {
                        var comparator = array[j] as IComparable<T>;
                        if (comparator == null)
                            Swap(ref array[j], ref array[j + 1]);
                        else
                            if (comparator.CompareTo(array[j + 1]) > 0)
                            Swap(ref array[j], ref array[j + 1]);
                    }
                }
        }

        public void Sort(T[] array, Compare compare)
        {
            var comparerAdepter = new InterfaceComparerAdapter<T>(compare);
            Sort(array, comparerAdepter);
        }
    }


    public class BubbleSorterDelegateLock<T>
    {
        public delegate int Compare(T x, T y);

        static void Swap(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        public void Sort(T[] array, IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }
            Sort(array,comparer.Compare);
        }

        public void Sort(T[] array, Compare compare)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length-1; j++)
                {
                    if (compare != null)
                    {
                        if (compare(array[j], array[j + 1]) > 0)
                            Swap(ref array[j], ref array[j + 1]);
                    }
                    else
                    {
                        var comparable = array[j] as IComparable<T>;
                        if (comparable==null)
                            Swap(ref array[j],ref array[j+1]);
                        else
                        {
                            if (comparable.CompareTo(array[j+1])>0)
                                Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
        }
    }
}
