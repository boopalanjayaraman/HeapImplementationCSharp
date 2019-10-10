using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{
    /// <summary>
    /// Abstract definition for Heap Data structure
    /// </summary>
    /// <typeparam name="T">type of the data's base data type</typeparam>
    public abstract class AbstractHeap<T> : IHeap<T>
        where T : IComparable
    {
        /// <summary>
        /// Underlying data array where Heap is being maintained
        /// </summary>
        protected T[] _data = null;

        /// <summary>
        /// Size of the underlying heap. Heap Size could be less than array size.
        /// Represents only existent members length
        /// </summary>
        protected int _size = 0;

        /// <summary>
        /// Abstract method for adding / inserting a new element into the heap
        /// </summary>
        /// <param name="item"></param>
        public abstract void Add(T item);

        /// <summary>
        /// Abstract method for extracting / popping the root element
        /// </summary>
        /// <returns></returns>
        public abstract T Pop();

        /// <summary>
        /// Abstract method for heapify up operation
        /// Heapify upward - keeps up the heap property upwards for parents
        /// </summary>
        /// <param name="index">index from which to start upwards</param>
        protected abstract void HeapifyUp(int index);

        /// <summary>
        /// Abstract method for heapify down operation
        /// Heapifying downward - keeps up the heap property downward for descendants
        /// </summary>
        /// <param name="index">index from which to start downwards</param>
        protected abstract void HeapifyDown(int index);

        /// <summary>
        /// Gets the value of the root element without extracting / popping the item out.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return _data[0];
        }

        /// <summary>
        /// Says if the heap contains elements to extract / pop.
        /// </summary>
        /// <returns></returns> 
        public bool CanPop()
        {
            return _size > 0;
        }

        protected int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        protected int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        protected int GetParentIndex(int index)
        {
            if (index == 0)
            {
                return 0;
            }
            else
            {
                int result = (index - 1) / 2;
                return result;
            }

        }

        protected void Swap(int first, int second)
        {
            T temp = _data[first];
            _data[first] = _data[second];
            _data[second] = temp;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("| ");
            foreach (var item in _data)
            {
                if (item != null)
                {
                    builder.Append(item);
                }
                else
                {
                    builder.Append("null");
                }
                builder.Append(" | ");
            }
            return builder.ToString();
        }
    }
}
