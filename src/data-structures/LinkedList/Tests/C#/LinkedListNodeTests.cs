using Data.LinkedList;
using NUnit.Framework;
using System;

namespace LinkedListTest
{
    [TestFixture]
    public class LinkedListNodeTests
    {
        [Test]
        public void Ctor_EmptyValue()
        {
           Assert.Throws<ArgumentNullException>(() => new LinkedListNode<Person>(null));
           Assert.Throws<ArgumentNullException>(() => new LinkedListNode<int>(default(int)));
        }

        [Test]
        public void Ctor_NextProperty()
        {
            var person1 = new Person { FirstName = "Test1", LastName = "User" };
            var person2 = new Person { FirstName = "Test2", LastName = "User" };
            var n2 = new LinkedListNode<Person>(person2);
            var n1 = new LinkedListNode<Person>(person1, n2);
            Assert.AreEqual(n1.Next, n2, "Nodes are not equal.");
            Assert.AreEqual(n1.Value, person1, "Values are not equal.");

        }
    }
}
