using System;

namespace Caro
{
    class CaroStack<T>
    {
        private int capacity;
        private int count;
        private int index;
        private T[] save;
        
        public CaroStack(int capacity)
        {
            this.capacity = capacity;
            save = new T[capacity];
            index = 0; count = 0;
        }

        public int Capacity()
        {
            return capacity;
        }

        public int Count()
        {
            return count;
        }

        public void Push(T item)
        {
            if (index == capacity - 1) index = 0;
            else index++;
            if (count < capacity) count++;
            save[index] = item;
        }

        public T Pop()
        {
            if (count > 0)
            {
                int temp = index;
                if (index == 0) index = capacity - 1;
                else index--;
                count--;
                return save[temp];
            }
            else throw new NullReferenceException();
        }

        public T Peek()
        {
            if (count > 0) return save[index];
            else throw new NullReferenceException();
        }
    }
}
