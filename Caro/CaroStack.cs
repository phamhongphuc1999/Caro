using System;
using System.Collections.Generic;

namespace Caro
{
    class CaroStack<T>
    {
        //private int capacity;
        //private int count;
        //private int index;
        //private T[] save;
        private int maxReturn;
        private int count;
        private Stack<T> save;
        
        public CaroStack(int maxReturn)
        {
            //this.capacity = capacity;
            //save = new T[capacity];
            //index = 0; count = 0;
            save = new Stack<T>();
            this.maxReturn = maxReturn;
            count = maxReturn;
        }

        public int Count()
        {
            return save.Count;
        }

        public void Push(T item)
        {
            //if (index == capacity - 1) index = 0;
            //else index++;
            //if (count < capacity) count++;
            //save[index] = item;
            count = maxReturn;
            save.Push(item);
        }

        public T Pop()
        {
            //if (count > 0)
            //{
            //    int temp = index;
            //    if (index == 0) index = capacity - 1;
            //    else index--;
            //    count--;
            //    return save[temp];
            //}
            //else throw new NullReferenceException();
            if (save.Count > 0 && count > 0)
            {
                count--;
                return save.Pop();
            }
            else throw new NullReferenceException();
        }

        public T Peek()
        {
            //if (count > 0) return save[index];
            //else throw new NullReferenceException();
            if (save.Count > 0) return save.Peek();
            else throw new NullReferenceException();
        }
    }
}
