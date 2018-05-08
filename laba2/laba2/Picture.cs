using System;
using System.Collections.Generic;

namespace laba2
{
    public enum ChangeType
    {
        Add,
        Insert,
        Delete,
        Set
    }

    public delegate void ChangeHandler(ChangeType change);

    public class Picture<T>
    {
        public Picture()
        {
            Elements = new List<T>();
        }

        public List<T> Elements { get; }

        public event ChangeHandler Changed;

        public void Add(T v)
        {
            Elements.Add(v);
            if (Changed != null) Changed(ChangeType.Add);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Elements.Count) throw new IndexOutOfRangeException();
            return Elements[index];
        }

        public void Set(int index, T v)
        {
            if (index < 0 || index >= Elements.Count) throw new IndexOutOfRangeException();
            Elements[index] = v;
            if (Changed != null) Changed(ChangeType.Set);
        }

        public void Insert(int index, T v)
        {
            if (index < 0 || index >= Elements.Count) throw new IndexOutOfRangeException();
            Elements.Insert(index, v);
            if (Changed != null) Changed(ChangeType.Insert);
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= Elements.Count) throw new IndexOutOfRangeException();
            Elements.RemoveAt(index);
            if (Changed != null) Changed(ChangeType.Delete);
        }

        public override string ToString()
        {
            return "[" + string.Join(", ", Elements) + "]";
        }
    }

    public class TooBigException : Exception
    {
        public TooBigException(string item) : base($"Figure {item} you trying to create is too big. Be aware of this in future.")
        {
        }
    }
}