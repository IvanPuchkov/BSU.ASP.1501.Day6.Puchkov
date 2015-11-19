namespace BubbleSorter
{
    public class InterfaceComparerAdapter<T>:IComparer<T>
    {
        private readonly BublleSorterInterfaceLock<T>.Compare _comparator;
        public int Compare(T x, T y) => _comparator(x, y);
        public InterfaceComparerAdapter(BublleSorterInterfaceLock<T>.Compare comparator)
        {
            _comparator = comparator;
        }
        
    }
}
