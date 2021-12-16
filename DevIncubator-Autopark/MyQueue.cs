namespace DevIncubatorAutopark
{
    internal class MyQueue<T>
    {
        private const int DefaultSize = 10;
        private T[] _queueArr;
        private int _length;
        private int _endIndex;

        public MyQueue()
        {
            _queueArr = new T[DefaultSize];
        }

        public MyQueue(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("Queue size cannot be less than 0", nameof(length));
            }
            _queueArr = new T[length];
            _length = length;
            _endIndex = 0;
        }

        public MyQueue(IEnumerable<T> queue)
        {
            if (queue is null)
            {
                throw new ArgumentNullException();
            }
            _queueArr = new T[DefaultSize];
            foreach (var item in queue)
            {
                Enqueue(item);
            }
        }

        public int Count => _endIndex;

        public void Resize()
        {
            var newQueue = new T[_length * 2];

            Array.Copy(_queueArr, newQueue, _queueArr.Length);

            _queueArr = newQueue;
            _length *= 2;
        }

        public void Enqueue(T element)
        {
            if (_length - 1 == _endIndex)
            {
                Resize();
            }

            _queueArr.SetValue(element, _endIndex);
            _endIndex++;
        }

        public T Dequeue()
        {
            if (Count != 0)
            {
                var dequeueItem = _queueArr[0];
                var newQueue = new T[_queueArr.Length - 1];
                Array.Copy(_queueArr, 1, newQueue, 0, --_endIndex);
                _queueArr = newQueue;

                return dequeueItem;
            }

            return default;
        }

        public void Clear()
        {
            Array.Clear(_queueArr, 0, _queueArr.Length);
            _endIndex = 0;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < _queueArr.Length; i++)
            {
                if (_queueArr[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _endIndex; i++)
            {
                yield return _queueArr[i];
            }
        }
    }
}
