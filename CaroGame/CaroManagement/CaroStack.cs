using System;
using System.Collections.Generic;

namespace CaroGame.CaroManagement
{
    class CaroStack<T>
    {
        private int maxReturn;
        private int count;
        private Stack<T> save;

        public CaroStack(int maxReturn)
        {
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
            count = maxReturn;
            save.Push(item);
        }

        public T Pop()
        {
            if (save.Count > 0 && count > 0)
            {
                count--;
                return save.Pop();
            }
            else throw new Exception();
        }

        public T Peek()
        {
            if (save.Count > 0) return save.Peek();
            else throw new Exception();
        }
    }
}
