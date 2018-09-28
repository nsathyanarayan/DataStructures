using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.LinkedList;

namespace LinkedListTest
{
    [TestFixture]
    public class LinkedListTest
    {
        [Test]
        public void Ctor_Success()
        {
            var list = new Data.LinkedList.LinkedList<Person>();
            Assert.IsNull(list.Head, "Head is not null.");
            Assert.IsNull(list.Tail, "Tail is not null.");
        }

        [Test]
        public void Prepend_Success()
        {
            var person1 = new Person { FirstName = "Test1", LastName = "User" };
            var person2 = new Person { FirstName = "Test2", LastName = "User" };
            var list = new Data.LinkedList.LinkedList<Person>();
            list.Prepend(person1);
            Assert.AreEqual(list.Head.Value.FirstName, "Test1", "First Names do not match.");
            Assert.AreEqual(list.Tail.Value.FirstName, "Test1", "First Names do not match.");

            // Now prepend one more node.
            list.Prepend(person2);
            Assert.AreEqual(list.Head.Value.FirstName, "Test2", "First Names do not match.");
            Assert.AreEqual(list.Head.Next.Value.FirstName, "Test1", "First Names do not match.");
            Assert.AreEqual(list.Tail.Value.FirstName, "Test1", "First Names do not match.");
            Assert.IsNull(list.Tail.Next, "Tail node must have null node next to it.");
        }

        [Test]
        public void Append_Success()
        {
            var person1 = new Person { FirstName = "Test1", LastName = "User" };
            var person2 = new Person { FirstName = "Test2", LastName = "User" };
            var list = new Data.LinkedList.LinkedList<Person>();
            list.Append(person1);
            Assert.AreEqual(list.Head.Value.FirstName, "Test1", "First Names do not match.");
            Assert.AreEqual(list.Tail.Value.FirstName, "Test1", "First Names do not match.");

            // Now prepend one more node.
            list.Append(person2);
            Assert.AreEqual(list.Head.Value.FirstName, "Test1", "First Names do not match.");
            Assert.AreEqual(list.Head.Next.Value.FirstName, "Test2", "First Names do not match.");
            Assert.AreEqual(list.Tail.Value.FirstName, "Test2", "First Names do not match.");
            Assert.IsNull(list.Tail.Next, "Tail node must have null node next to it.");
        }

        [Test]
        public void Delete_Success()
        {
            var person1 = new Person { FirstName = "Test1", LastName = "User" };
            var personDeleted = new Person { FirstName = "TestDeleted", LastName = "UserDeleted" };
            var person2 = new Person { FirstName = "Test2", LastName = "User" };
            var list = new Data.LinkedList.LinkedList<Person>();
            list.Append(person1);
            Assert.AreEqual(list.Head.Value.FirstName, "Test1", "First Names do not match.");
            Assert.AreEqual(list.Tail.Value.FirstName, "Test1", "First Names do not match.");

            // Now prepend one more node.
            list.Append(personDeleted);
            list.Append(person2);
            Assert.AreEqual(list.Head.Value.FirstName, "Test1", "First Names do not match.");
            Assert.AreEqual(list.Head.Next.Value.FirstName, "TestDeleted", "First Names do not match.");
            Assert.AreEqual(list.Tail.Value.FirstName, "Test2", "First Names do not match.");
            Assert.IsNull(list.Tail.Next, "Tail node must have null node next to it.");

            list.Delete(personDeleted);
            Assert.AreEqual(list.Head.Value.FirstName, "Test1", "First Names do not match.");
            Assert.AreEqual(list.Head.Next.Value.FirstName, "Test2", "First Names do not match.");
            Assert.AreEqual(list.Tail.Value.FirstName, "Test2", "First Names do not match.");
            Assert.IsNull(list.Tail.Next, "Tail node must have null node next to it.");

        }

        [Test]
        public void Delete_SuccessWithComparator()
        {
            var person1 = new Person { FirstName = "Test1", LastName = "User" };
            var personDeleted = new Person { FirstName = "TestDeleted", LastName = "UserDeleted" };
            var person2 = new Person { FirstName = "Test2", LastName = "User" };
            var list = new Data.LinkedList.LinkedList<Person>(Person.Comparator);
            list.Append(person1);
            Assert.AreEqual(list.Head.Value.FirstName, "Test1", "First Names do not match.");
            Assert.AreEqual(list.Tail.Value.FirstName, "Test1", "First Names do not match.");

            // Now prepend one more node.
            list.Append(personDeleted);
            list.Append(person2);
            Assert.AreEqual(list.Head.Value.FirstName, "Test1", "First Names do not match.");
            Assert.AreEqual(list.Head.Next.Value.FirstName, "TestDeleted", "First Names do not match.");
            Assert.AreEqual(list.Tail.Value.FirstName, "Test2", "First Names do not match.");
            Assert.IsNull(list.Tail.Next, "Tail node must have null node next to it.");

            list.Delete(personDeleted);
            Assert.AreEqual(list.Head.Value.FirstName, "Test1", "First Names do not match.");
            Assert.AreEqual(list.Head.Next.Value.FirstName, "Test2", "First Names do not match.");
            Assert.AreEqual(list.Tail.Value.FirstName, "Test2", "First Names do not match.");
            Assert.IsNull(list.Tail.Next, "Tail node must have null node next to it.");

        }

        [Test]
        public void Find_Success()
        {
            var person1 = new Person { FirstName = "Test1", LastName = "User" };
            var personDeleted = new Person { FirstName = "TestDeleted", LastName = "UserDeleted" };
            var person2 = new Person { FirstName = "Test2", LastName = "User" };
            var list = new Data.LinkedList.LinkedList<Person>(Person.Comparator);
            list.Append(person1);
            list.Append(personDeleted);
            list.Append(person2);
            var node = list.Find(personDeleted);
            Assert.AreEqual(node.Value.FirstName, "TestDeleted", "First names do not match.");
            Assert.AreEqual(node, list.Head.Next, "Node is not placed in the right place");
         }

        [Test]
        public void DeleteHead_Success()
        {
            var person1 = new Person { FirstName = "Test1", LastName = "User" };
            var personDeleted = new Person { FirstName = "TestDeleted", LastName = "UserDeleted" };
            var person2 = new Person { FirstName = "Test2", LastName = "User" };
            var list = new Data.LinkedList.LinkedList<Person>(Person.Comparator);
            list.Append(person1);
            list.Append(personDeleted);
            list.Append(person2);
            list.DeleteHead();
            Assert.AreEqual(list.Head.Value.FirstName, "TestDeleted", "Head is not deleted.");
        }

        [Test]
        public void DeleteTail_Success()
        {
            var person1 = new Person { FirstName = "Test1", LastName = "User" };
            var personDeleted = new Person { FirstName = "TestDeleted", LastName = "UserDeleted" };
            var person2 = new Person { FirstName = "Test2", LastName = "User" };
            var list = new Data.LinkedList.LinkedList<Person>(Person.Comparator);
            list.Append(person1);
            list.Append(personDeleted);
            list.Append(person2);
            list.DeleteTail();
            Assert.AreEqual(list.Tail, list.Head.Next,  "Tail is not deleted.");
            Assert.IsNull(list.Tail.Next, "Tail is not deleted.");
            Assert.IsNull(list.Head.Next.Next, "Tail is not deleted.");
        }
    }
}
