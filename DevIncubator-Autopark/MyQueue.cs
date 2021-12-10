namespace DevIncubatorAutopark
{
    internal class MyQueue<T>
    {
        private const int DefaultSize = 10;
        private T[] queueArr;
        private int length;
        private int startIndex;
        private int endIndex;

        public MyQueue()
        {
            queueArr = new T[DefaultSize];
        }

        public MyQueue(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Размер очереди не может быть меньше 0", nameof(length));
            }
            queueArr = new T[length];
            this.length = length;
            endIndex = 0;
            startIndex = 0;
        }

        public MyQueue(T[] queue)
        {
            queueArr = queue ?? throw new ArgumentNullException(nameof(queue), "Исходные элементы очереди не могут быть null");
            length = queueArr.Length;
            endIndex = queueArr.Length - 1;
        }

        public int Count => endIndex - startIndex;

        public void Resize()
        {
            var newQueue = new T[length * 2];

            for (int i = 0; i < queueArr.Length; i++)
            {
                newQueue[i] = queueArr[i];
            }

            queueArr = newQueue;
            length *= 2;
        }

        public void Enqueue(T element)
        {
            if (length - 1 == endIndex)
            {
                Resize();
            }

            queueArr.SetValue(element, endIndex);
            endIndex++;
        }

        public T Dequeue()
        {
            if (startIndex != endIndex)
            {
                var elementToDequeue = queueArr[startIndex];
                startIndex++;

                return elementToDequeue;
            }

            return default;
        }

        public void Clear()
        {
            if (length <= 0)
            {
                Array.Clear(queueArr, 0, queueArr.Length);
            }
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < queueArr.Length; i++)
            {
                if (queueArr[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var start = startIndex;
            var end = endIndex;
            while (start != end)
            {
                yield return queueArr[end++];
            }
        }
    }
}
