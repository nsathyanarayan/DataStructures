using System;
namespace Data.LinkedList
{
    public class LinkedListNode<T>
    {
        /// <summary>
        /// Initializes an instance of <see cref="LinkedListNode"/>.
        /// </summary>
        /// <param name="value">Value for this node.</param>
        /// <param name="next">The next node that gets attached to this node.</param>
        public LinkedListNode(T value, LinkedListNode<T> next = null)
        {
            if( ObjectData<T>.IsEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }                   

            this.Value = value;
            this.Next = next;
        }

        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Gets or sets the node attached to the current node.
        /// </summary>
        public LinkedListNode<T> Next { get; set; }
    }
}
