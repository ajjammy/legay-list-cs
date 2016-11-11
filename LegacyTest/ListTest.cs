using Legacy;
using NUnit.Framework;
using System;

namespace LegacyTest
{
    [TestFixture]
    public class ListTest
    {
        private LegacyList empty;
        private LegacyList oneElement;
        private LegacyList manyElement;

        [SetUp]
        public void Setup()
        {
            empty = new LegacyList();
            oneElement = new LegacyList();
            oneElement.Add("sophia");
            manyElement = new LegacyList();
            manyElement.Add("josh");
            manyElement.Add("sasha");
        }

        [Test]
        public void IsEmpty()
        {
            Assert.True(empty.IsEmpty());
            Assert.True(!oneElement.IsEmpty());
        }

        [Test]
        public void Contains()
        {
            Assert.True(manyElement.Contains("josh"));
            Assert.True(!manyElement.Contains("tracy"));
        }

        [Test]
        public void Size()
        {
            Assert.AreEqual(0, empty.Size());
            Assert.AreEqual(1, oneElement.Size());
            Assert.True(manyElement.Size() > 1);
        }

        [Test]
        public void AllowDuplicates()
        {
            manyElement.Add("sasha");
            Assert.AreEqual(3, manyElement.Size());
        }

        [Test]
        public void Remove()
        {
            Assert.True(oneElement.Remove("sophia"));
            Assert.AreEqual(0, oneElement.Size());
            Assert.True(manyElement.Remove("josh"));
            Assert.AreEqual(1, manyElement.Size());
        }

        [Test]
        public void RemoveCollapsesList()
        {
            manyElement.Add("tracy");
            Assert.AreEqual(3, manyElement.Size());
            manyElement.Remove("sasha");
            Assert.AreEqual(2, manyElement.Size());
            Assert.AreEqual("tracy", manyElement.Get(1));
        }

        [Test]
        public void GetWhenIndexOutOfBounds()
        {
            Assert.Throws<IndexOutOfRangeException>(() => empty.Get(12));
        }

        [Test]
        public void Expandability()
        {
            LegacyList expandableList = new LegacyList();
            Assert.AreEqual(10, expandableList.Capacity());
            for (int i = 0; i < 11; i++)
                expandableList.Add(i);
            Assert.AreEqual(11, expandableList.Size());
            Assert.AreEqual(20, expandableList.Capacity());
        }

        [Test]
        public void Override()
        {
            oneElement.Set(0, "mary");

            Assert.AreEqual("mary", oneElement.Get(0));
        }

        [Test]
        public void OverrideWhenOutOfBounds()
        {
            try
            {
                oneElement.Set(8, "mary");
                Assert.Fail("should have thrown IndexOutOfRangeException");
            }
            catch (IndexOutOfRangeException expectedException)
            {
                Assert.True(true, "expected behavior");
            }
        }

        [Test]
        public void ReadOnlyOnAdd()
        {
            oneElement.SetReadOnly(true);
            oneElement.Add("eva");
            Assert.AreEqual(1, oneElement.Size());
        }

        [Test]
        public void ReadOnlyOnSet()
        {
            oneElement.SetReadOnly(true);
            oneElement.Set(0, "eva");
            Assert.AreEqual("sophia", oneElement.Get(0));
        }

        [Test]
        public void ReadOnlyOnRemove()
        {
            oneElement.SetReadOnly(true);
            oneElement.Remove("sophia");
            Assert.AreEqual(1, oneElement.Size());
        }

    }
}

