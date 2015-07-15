using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    public class MyArrayList<T> : IEnumerable
    {
        T[] data = new T[10];
        int len = 0;

        public void add(T o)
        {
            len++;
            if (len > data.Length)
            {
                T[] newData = new T[(len-1)*2];
                Array.Copy(data, 0, newData, 0, len - 1);
                this.data = newData;
            }
            this.data[len - 1] = o;
        }
        public int size()
        {
            return len;
        }
        public T get(int index)
        {
            if (len == 0 || len <= index || index < 0)
            {
                throw new MyOutOfBoundsException();
            }

            return data[index];
        }
        public void set(int index, T o)
        {
            if (len == 0 || len <= index)
            {
                throw new MyOutOfBoundsException();
            }
            data[index] = o;

        }
        public void remove(int index)
        {
            if (len == 0 || len <= index)
            {
                throw new MyOutOfBoundsException();
            }
            for (int i = index; i < data.Length-1; i++)
            {
                data[i] = data[i + 1];
            }
            len--;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        class MyEnumerator : IEnumerator<T>
        {
            MyArrayList<T> collection;
            public MyEnumerator(MyArrayList<T> collection)
            {
                this.collection = collection;
            }
            int index = -1;

            public T Current
            {
                get { return collection.get(index); }
            }

            object IEnumerator.Current
            {
                get { return collection.get(index); }
            }

            public bool MoveNext()
            {
                index++;
                return index < collection.size();
            }

            public void Reset()
            {
                index = -1;
            }
            public void Dispose()
            {
                //does nothing
            }

        }

        
    }
    public class MyOutOfBoundsException : Exception
    {
    }
}
