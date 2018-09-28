using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.LinkedList
{
    /// <summary>
    /// class that implements Linked List Data structure.
    /// </summary>
    public class LinkedList<T>
    {
        /// <summary>
        /// Delegate that compares the two values.
        /// </summary>
        /// <param name="s1">Source Value.</param>
        /// <param name="s2">Target Value.</param>
        /// <returns>Result of the comparision. 0 if equal, 1 if s1>s2 and -1 if s1<s2.</returns>
        public delegate int Comparator(T s1, T s2);

        /// <summary>
        /// Initializes an instance of <see cref="LinkedList"/>.
        /// </summary>
        /// <param name="comparator">An instance of <see cref="Comparator"/>.</param>
        public LinkedList(Comparator comparator = null)
        {
            if( comparator != null)
            {
                this.ValueComparator = comparator;
            }

            this.Head = null;
            this.Tail = null;
        }

        /// <summary>
        /// Identifies the Head node.
        /// </summary>
        public LinkedListNode<T> Head { get; set; }

        /// <summary>
        /// Identifies the Tail node.
        /// </summary>
        public LinkedListNode<T> Tail { get; set; }

        /// <summary>
        /// Gets or sets the comparator to compare the values.
        /// </summary>
        public Comparator ValueComparator { get; private set; }

        /// <summary>
        /// Attaches the new value to the head of the linked list.
        /// </summary>
        /// <param name="value">Node Value.</param>
        public LinkedList<T> Prepend(T value)
        {
            if (ObjectData<T>.IsEmpty(value))
            {
                return null;
            }

            var node = new LinkedListNode<T>(value, this.Head);
            this.Head = node;
            if( this.Tail == null)
            {
                this.Tail = node;
            }

            return this;
        }

        /// <summary>
        /// Attaches the new value to the tail of the linked list.
        /// </summary>
        /// <param name="value">Node Value.</param>
        public LinkedList<T> Append(T value)
        {
            if (ObjectData<T>.IsEmpty(value))
            {
                return null;
            }

            var node = new LinkedListNode<T>(value);
            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
                return this;
            }

            this.Tail.Next = node;
            this.Tail = node;
            return this;
        }

        /// <summary>
        /// Deletes a given value from the linked list.
        /// </summary>
        /// <returns>A instance of <see cref="LinkedList"/>.</returns>
        public LinkedList<T> Delete(T value)
        {
            if (ObjectData<T>.IsEmpty(value))
            {
                return null;
            }

            if (this.Head == null)
            {
                return null;
            }

            LinkedListNode<T> currentNode = this.Head;
            LinkedListNode<T> previousNode = this.Head;
            bool matchFound = false;
            while (currentNode != null)
            {
                int result = this.ValueComparator != null ? this.ValueComparator(currentNode.Value, value) : currentNode.Value.GetHashCode().CompareTo(value.GetHashCode());
                if (result == 0)
                {
                    matchFound = true;
                    break;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (matchFound)
            {
                // if it is a Head node, adjust the head pointer.
                if( currentNode == this.Head)
                {
                    this.Head = currentNode.Next;
                    return this;
                }

                // if the node is a tail node, adjust the tail pointer
                if( currentNode == this.Tail)
                {
                    this.Tail = previousNode;
                }

                // Adjust any in between nodes.
                previousNode.Next = currentNode.Next;
            }

            return this;
        }

        /// <summary>
        /// Finds a value in a linked list.
        /// </summary>
        /// <param name="value">Value to be searched.</param>
        /// <returns>A <see cref="LinkedListNode"/> matching the value.</returns>
        public LinkedListNode<T> Find(T value)
        {
            if (ObjectData<T>.IsEmpty(value))
            {
                return null;
            }

            if (this.Head == null)
            {
                return null;
            }

            LinkedListNode<T> currentNode = this.Head;
            bool matchFound = false;
            while (currentNode != null)
            {
                int result = this.ValueComparator != null ? this.ValueComparator(currentNode.Value, value) : currentNode.Value.GetHashCode().CompareTo(value.GetHashCode());
                if (result == 0)
                {
                    matchFound = true;
                    break;
                }
                
                currentNode = currentNode.Next;
            }

            return matchFound ? currentNode : null;
        }

        /// <summary>
        /// Deletes a head value.
        /// </summary>
        /// <returns>A <see cref="LinkedListNode"/> matching the value.</returns>
        public LinkedListNode<T> DeleteHead()
        {
            if (this.Head == null)
            {
                return null;
            }

            var node = this.Head;
            if( this.Head.Next == null)
            {
                this.Head = null;
                this.Tail = null;
                return node;
            }

            this.Head = this.Head.Next;
            return node;
        }


        /// <summary>
        /// Deletes a tail value.
        /// </summary>
        /// <returns>A <see cref="LinkedListNode"/> matching the value.</returns>
        public LinkedListNode<T> DeleteTail()
        {
            if (this.Tail == null || this.Head == null)
            {
                return null;
            }
            
            if ( this.Head == this.Tail)
            {
                var node = this.Tail;
                this.Head = null;
                this.Tail = null;
                return node;
            }

            var currentNode = this.Head;
            var previousNode = this.Head;
            while( currentNode.Next != null)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            this.Tail = previousNode;
            previousNode.Next = null;
            return currentNode;
        }
    }
}
