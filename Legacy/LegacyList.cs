using System;

namespace Legacy
{
    public class LegacyList
    {
        private Object[] elements = new Object[10];
        private int size = 0;
        private bool readOnly;

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Add(Object element)
        {
            if (!readOnly)
            {
                int newSize = size + 1;
                if (newSize > elements.Length)
                {
                    Object[] newElements =
                        new Object[elements.Length + 10];
                    for (int i = 0; i < size; i++)
                        newElements[i] = elements[i];
                    elements = newElements;
                }
                elements[size++] = element;
            }
        }

        public bool Contains(Object element)
        {
            for (int i = 0; i < size; i++)
                if (elements[i].Equals(element))
                    return true;
            return false;
        }

        public int Size()
        {
            return this.size;
        }

        public bool Remove(Object element)
        {
            if (readOnly)
                return false;
            else
                for (int i = 0; i < size; i++)
                    if (elements[i].Equals(element))
                    {
                        elements[i] = null;
                        Object[] newElements = new Object[size - 1];
                        int k = 0;
                        for (int j = 0; j < size; j++)
                        {
                            if (elements[j] != null)
                                newElements[k++] = elements[j];
                        }
                        size--;
                        elements = newElements;
                        return true;
                    }
            return false;
        }

        public Object Get(int i)
        {
            return elements[i];
        }

        public int Capacity()
        {
            return elements.Length;
        }

        public void Set(int i, Object value)
        {
            if (!readOnly)
            {
                if (i >= size)
                    throw new IndexOutOfRangeException();
                elements[i] = value;
            }
        }

        public void SetReadOnly(bool b)
        {
            readOnly = b;
        }
    }
}