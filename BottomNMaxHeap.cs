﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{
    /// <summary>
    /// Fetch Bottom N items with a Max Heap implementation (instead of Min Heap)
    /// This keeps only N items in the internal array to minimize the time spent on heapifying up / down in a larger array
    /// as opposed to traditional min / max heaps.
    /// </summary>
    /// <typeparam name="T">any type that implements IComparable</typeparam>
    public class BottomNMaxHeap<T> : AbstractHeap<T>
        where T : IComparable
    {
        public BottomNMaxHeap(int capacity)
        {
            _data = new T[capacity];
        }

        /// <summary>
        /// This adds the element to internal array-based heap structure 
        /// only if the element is smaller than the minimum item that is already on the structure.
        /// Also this re-arranges the items if size exceeds the defined limit.
        /// </summary>
        /// <param name="item">item to be added</param>
        public override void Add(T item)
        {
            if (item == null)
            {
                throw new Exception("Cannot add null element.");
            }
            if (_size < this._data.Count() || item.CompareTo(this.Peek()) < 0)
            {
                if (_size >= this._data.Count())
                {
                    //// Pops the maximum item from the current heap
                    this.Pop();
                }
                InternalAdd(item);
            }

        }

        private void InternalAdd(T item)
        {
            int index = _size;
            _data[index] = item;
            _size++;
            HeapifyUp(index);
        }

        /// <summary>
        /// Pops the root item from the heap.
        /// This is top-most item / maximum in the current structure.
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
        /// Heapfiying up - keeps up the heap property upwards -  brings up larger elements, if any, to the top positions 
        /// and does this recursively in the current hierarchy by swapping
        /// </summary>
        /// <param name="index">index of the element</param>
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
        /// Heapfiying down  - keeps up the heap property upwards -  brings up larger elements, if any, to the top positions 
        /// and does this recursively in the current hierarchy by swapping
        /// </summary>
        /// <param name="index">index of the element</param>
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
