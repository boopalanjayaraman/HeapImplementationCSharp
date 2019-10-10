using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{
    /// <summary>
    /// Contract for Heap data structure
    /// </summary>
    public interface IHeap<T> where T : IComparable
    {
        /// <summary>
        /// Method for inserting an element into the heap data strucutre
        /// Performs upward heapifying operation after inserting the element at the end
        /// </summary>
        /// <param name="item">item to be added</param>
        void Add(T item);

        /// <summary>
        /// Extract method.
        /// Pops the root of the heap data structure - minimum / maximum of the current data
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// Gets the value of the root element without extracting / popping the item out.
        /// </summary>
        /// <returns></returns>
        T Peek();

        /// <summary>
        /// Says if the heap contains elements to extract / pop.
        /// </summary>
        /// <returns></returns>
        bool CanPop();
    }
}
