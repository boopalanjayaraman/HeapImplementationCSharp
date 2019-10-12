using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{
    /// <summary>
    /// Fetch Top N items with a Min Heap implementation (instead of Max Heap)
    /// This keeps only N items in the internal array to minimize the time spent on heapifying up / down in a larger array
    /// as opposed to traditional min / max heaps.
    /// The Top N items appear in ascending order because it is a min heap.
    /// </summary>
    /// <typeparam name="T">any type that implements</typeparam>
    public class TopNEntityMinHeap<T, TResult> : AbstractHeap<T>
        where T : class
        where TResult : IComparable
    {
        Func<T, TResult> _getValue = null;

        public TopNEntityMinHeap(int capacity, Func<T, TResult> selector)
        {
            _data = new T[capacity];
            _getValue = selector;
        }

        /// <summary>
        /// This adds the element to internal array-based heap structure 
        /// only if the element is only greater than the maximum item that is already on the structure.
        /// Also this re-arranges the items if size exceeds the defined limit.
        /// </summary>
        /// <param name="item">item to be added</param>
        public override void Add(T item)
        {
            if (item == null)
            {
                throw new Exception("Cannot add null element.");
            }

            if (_size < this._data.Count() || _getValue(item).CompareTo(_getValue(this.Peek())) > 0)
            {
                if (_size >= this._data.Count())
                {
                    //// Pops the minimum item from the current heap
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
        /// This is top-most item / minimum in the current structure.
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
        /// Heapfiying up - keeps up the heap property upwards -  brings up smaller elements, if any, to the top positions 
        /// and does this recursively in the current hierarchy by swapping
        /// </summary>
        /// <param name="index">index of the element</param>
        protected override void HeapifyUp(int index)
        {
            int parentIndex = GetParentIndex(index);
            if ((_data[parentIndex] != null) && (_getValue(_data[parentIndex]).CompareTo(_getValue(_data[index])) > 0))
            {
                Swap(parentIndex, index);
                HeapifyUp(parentIndex);
            }
        }

        /// <summary>
        /// Heapfiying down  - keeps up the heap property upwards -  brings up smaller elements, if any, to the top positions 
        /// and does this recursively in the current hierarchy by swapping
        /// </summary>
        /// <param name="index">index of the element</param>
        protected override void HeapifyDown(int index)
        {
            int smallest = index;
            int leftIndex = GetLeftChildIndex(index);
            int rightIndex = GetRightChildIndex(index);

            if ((leftIndex < _size) && (_getValue(_data[leftIndex]).CompareTo(_getValue(_data[index])) < 0))
            {
                smallest = leftIndex;
            }
            if ((rightIndex < _size) && (_getValue(_data[rightIndex]).CompareTo(_getValue(_data[smallest])) < 0))
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
