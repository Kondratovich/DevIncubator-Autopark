using System.Collections;

namespace DevIncubatorAutopark
{
    public class MyStack<T>
    {
        private T[] _array;
        private const int DefaultCapacity = 10;
        private const int ResizeValue = 2;
        public int Count { get; private set; }

        public MyStack()
        {
            _array = new T[DefaultCapacity];
        }

        public MyStack(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "Error, index out of range");

            _array = new T[count];
        }

        public MyStack(IEnumerable<T> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection), "Error, collection can`t be null");

            foreach (var element in collection)
            {
                Push(element);
            }
        }

        public void Clear()
        {
            Array.Clear(_array, 0, Count);
            Count = 0;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Error, array is empty");

            var item = _array[--Count];
            _array[Count] = default;

            return item;
        }

        public void Push(T item)
        {
            if (Count == _array.Length)
            {
                var newArray = new T[_array.Length * ResizeValue];
                Array.Copy(_array, newArray, Count);
                _array = newArray;
            }
            _array[Count] = item;
            Count += 1;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Can't peek item, stack is empty ");

            return _array[Count - 1];
        }

        public IEnumerator<T> GetEnumerator() => (IEnumerator<T>)_array.GetEnumerator();
    }
}
