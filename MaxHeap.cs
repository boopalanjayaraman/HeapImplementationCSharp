using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{
    /// <summary>
    /// A Generic Max Heap Implementation using Array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MaxHeap<T> : AbstractHeap<T>
        where T : IComparable
    {
        public MaxHeap(int capacity)
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
        /// Pops the root item - the maximum
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
            if ((_data[parentIndex] != null) && (_data[parentIndex].CompareTo(_data[index]) < 0))
            {
                Swap(parentIndex, index);
                HeapifyUp(parentIndex);
            }
        }

        /// <summary>
        /// Heapifying downward - keeps up the heap property downward for descendants
        /// </summary>
        /// <param name="index"></param>
        protected override void HeapifyDown(int index)
        {
            int largest = index;
            int leftIndex = GetLeftChildIndex(index);
            int rightIndex = GetRightChildIndex(index);

            if ((leftIndex < _size) && (_data[leftIndex].CompareTo(_data[index]) > 0))
            {
                largest = leftIndex;
            }
            if ((rightIndex < _size) && (_data[rightIndex].CompareTo(_data[largest]) > 0))
            {
                largest = rightIndex;
            }
            if (largest != index)
            {
                Swap(largest, index);
                HeapifyDown(largest);
            }
        }
    }

     
}
