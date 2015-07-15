using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayList;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testNewListIsEmpty()
        {
            var l = new MyArrayList<string>();
            Assert.AreEqual(l.size(), 0);
        }

        [TestMethod]
        public void testAddOneElementToList()
        {
            var l = new MyArrayList<string>();
            l.add("foo");
            Assert.AreEqual(l.size(), 1);
            Assert.AreEqual(l.get(0), "foo");
        }

        [TestMethod]
        public void testSetOneElement()
        {
            var l = new MyArrayList<string>();
            l.add("foo");
            Assert.AreEqual(l.size(), 1);
            l.set(0, "bar");
            Assert.AreEqual(l.get(0), "bar");
        }

        [TestMethod]
        [ExpectedException(typeof(MyOutOfBoundsException))]
        public void testGetOnEmptyList()
        {
            var l = new MyArrayList<string>();
            l.get(0);           
        }

        [TestMethod]
        [ExpectedException(typeof(MyOutOfBoundsException))]
        public void testGetOnOutOfRange()
        {
            var l = new MyArrayList<string>();
            l.add("str 1");           
            l.get(1);
        }

        [TestMethod]
        [ExpectedException(typeof(MyOutOfBoundsException))]
        public void testGetNegative()
        {
            var l = new MyArrayList<string>();
            l.add("str 1");
            l.get(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(MyOutOfBoundsException))]
        public void testSetOnEmptyList()
        {
            var l = new MyArrayList<string>();
            l.set(0, "i'm gona fail mother fucker");
        }

        [TestMethod]
        [ExpectedException(typeof(MyOutOfBoundsException))]
        public void testSetOnOutOfRange()
        {
            var l = new MyArrayList<string>();
            l.add("i'll be back");
            l.set(1, "i'm gona fail mother fucker");
        }

        [TestMethod]
        public void testEnumerator() {
            var l = new MyArrayList<string>();
            l.add("i'll be back");
            l.add("i'm gona fail mother fucker");

            var enumerator = l.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(enumerator.Current, "i'll be back");
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(enumerator.Current, "i'm gona fail mother fucker");
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]       
        public void testListExpansion()
        {
            var l = new MyArrayList<string>();
            for (int i = 0; i < 200; i++) {
                l.add("str#" + i);
            }

            int index = 0;
            foreach (var it in l) {
                Assert.AreEqual(it,"str#" + index);
                index++;
            }
            

        }

        [TestMethod]
        [ExpectedException(typeof(MyOutOfBoundsException))]
        public void testRemoveOnEmpty()
        {
            var l = new MyArrayList<string>();
            l.remove(0);
            
        }

        [TestMethod]
        [ExpectedException(typeof(MyOutOfBoundsException))]
        public void testRemoveNegative()
        {
            var l = new MyArrayList<string>();
            l.remove(-100);
        }

        [TestMethod]
        [ExpectedException(typeof(MyOutOfBoundsException))]
        public void testRemoveOutOfRange()
        {
            var l = new MyArrayList<string>();
            l.remove(100);
        }

       

        [TestMethod]
        public void testRemoveSingle()
        {
            var l = new MyArrayList<string>();
            l.add("foo");
            l.remove(0);
            Assert.AreEqual(l.size(), 0);
        }


        [TestMethod]        
        public void testRemoveInTheMiddleOfTheList()
        {
            var l = new MyArrayList<string>();
            l.add("foo");
            l.add("bar");
            l.add("biz");
            l.remove(1);
            Assert.AreEqual(l.size(), 2);
            Assert.AreEqual(l.get(0), "foo");
            Assert.AreEqual(l.get(1), "biz");
        }
        

       
    }
}
