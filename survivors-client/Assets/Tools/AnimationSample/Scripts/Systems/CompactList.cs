using System;
using Tools.AnimationSample.Scripts.Systems;
using UnityEngine;

namespace DefaultNamespace
{
    public class CompactList<T>
    {
        private T[] _array;
        private int _size;

        public T[] Buffer => _array;
        public int Count => _size;
        
        public CompactList(int capacity)
        {
            capacity = Mathf.Max(4, capacity);
            _array = new T[capacity];
        }

        public void Add(T item)
        {
            if (_size == _array.Length)
            {
                Array.Resize(ref _array, _array.Length * 2);
            }
            
            _array[_size++] = item;
        }

        public void RemoveAt(int index)
        {
            var lastIndex = _size - 1;
            
            if (index != lastIndex)
            {
                var lastElement = _array[lastIndex];
                _array[index] = lastElement;
            }
            
            _size--;
        }

        public SystemRegistryBase[] ToArray()
        {
            var array = new SystemRegistryBase[_size];
            
            Array.Copy(_array, 0, array, 0, _size);
            
            return array;
        }
    }
}