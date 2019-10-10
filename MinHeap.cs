using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{
    /// <summary>
    /// A generic min heap implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinHeap<T> : AbstractHeap<T> 
        where T : IComparable
    {
        public MinHeap(int capacity)
        {
            _data = new T[capacity];
        }

        /// <summary>
        /// Adds an element into the current heap structure
        /// </summary>
        /// <param name="item"></param>
        public override void Add(T item)
        {
            if (_size >= _data.Length)
            {
                throw new Exception("Cannot add further elements.");
            }
            if (item == null)
            {
                throw new Exception("Cannot add null element.");
            }
            int index = _size;
            _data[index] = item;
            _size++;
            HeapifyUp(index);
        }

        /// <summary>
        /// Pops the root item - the minimum
        /// And performs heapify-down operation
        /// </summary>
        /// <returns></returns>
        public override T Pop()
        {
            if (_size == 0)
            {
                throw new Exception("Cannot remove further elements.");
            }
            T item = _data[0];
            _data[0] = _data[_size - 1];
            _size--;
            HeapifyDown(0);
            return item;
        }

        /// <summary>
        /// Heapify upward - keeps up the heap property upwards for parents
        /// </summary>
        /// <param name="index">index from which to start upwards</param>
        protected override void HeapifyUp(int index)
        {
            int parentIndex = GetParentIndex(index);
            if ((_data[parentIndex] != null) && (_data[parentIndex].CompareTo(_data[index]) > 0))
            {
                Swap(parentIndex, index);
                HeapifyUp(parentIndex);
            }
        }

        /// <summary>
        /// Heapifying downward - keeps up the heap property downward for descendants
        /// </summary>
        /// <param name="index">index from which to start downwards</param>
        protected override void HeapifyDown(int index)
        {
            int smallest = index;
            int leftIndex = GetLeftChildIndex(index);
            int rightIndex = GetRightChildIndex(index);

            if ((leftIndex < _size) && (_data[leftIndex].CompareTo(_data[index]) < 0))
            {
                smallest = leftIndex;
            }
            if ((rightIndex < _size) && (_data[rightIndex].CompareTo(_data[smallest]) < 0))
            {
                smallest = rightIndex;
            }
            if (smallest != index)
            {
                Swap(smallest, index);
                HeapifyDown(smallest);
            }
        }
    }
}
