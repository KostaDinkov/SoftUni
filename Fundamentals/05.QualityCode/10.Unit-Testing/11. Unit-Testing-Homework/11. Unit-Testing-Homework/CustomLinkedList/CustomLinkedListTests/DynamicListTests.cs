namespace CustomLinkedListTests
{
    using System;
    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        private DynamicList<int> list;

        [TestInitialize]
        public void TestInit()
        {
            list = new DynamicList<int>();
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void DynamicList_AccessByIndex_ShouldThrowException()
        {
            list.Add(5);
            var result = list[1];
        }

        [TestMethod]
        public void Add()
        {
            list.Add(5);
            list.Add(10);
            list.Add(11);

            Assert.AreEqual(5, list[0]);
            Assert.AreEqual(10, list[1]);
            Assert.AreEqual(11, list[2]);
        }

        [TestMethod]
        public void RemoveAt()
        {
            list.Add(5);
            list.Add(1);
            list.Add(4);

            var case1 = list.RemoveAt(2);

            Assert.AreEqual(4, case1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void RemoveAt_InvalidIndex_ShouldThrowException()
        {
            //Test with Integer 
            list.Add(5);
            list.Add(1);
            list.Add(4);

            list.RemoveAt(4);
        }

        [TestMethod]
        public void Remove()
        {
            list.Add(5);
            list.Add(1);
            list.Add(4);

            var case1 = list.Remove(5);

            Assert.AreEqual(0, case1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Remove_InvalidIndex_ShouldThrowException()
        {
            list.Add(5);
            list.Add(1);
            list.Add(4);

            list.RemoveAt(5);
        }

        [TestMethod]
        public void IndexOfTest()
        {
            //Case with Integer
            list.Add(5);
            list.Add(1);
            list.Add(4);

            var case1 = list.IndexOf(4);

            Assert.AreEqual(2, case1, "Wrong results with integer data type");

            //Case with String
            var listString = new DynamicList<string>();
            listString.Add("Hello");
            listString.Add("Software");
            listString.Add("University");

            var case2 = listString.IndexOf("Software");

            Assert.AreEqual(1, case2, "Wrong results with string data type");
        }

        [TestMethod]
        public void ContainsTest()
        {
            // Case with Integer
            list.Add(5);
            list.Add(1);
            list.Add(4);

            var case1 = list.Contains(100);
            var case2 = list.Contains(4);

            Assert.AreEqual(false, case1, "Wrong results with integer data type");
            Assert.AreEqual(true, case2, "Wrong results with integer data type");

            // Case with string
            var listString = new DynamicList<string>();
            listString.Add("Hello");
            listString.Add("Software");
            listString.Add("University");

            var case3 = listString.Contains("Nakov");
            var case4 = listString.Contains("Software");

            Assert.AreEqual(false, case3, "Wrong results with string data type.");
            Assert.AreEqual(true, case4, "Wrong results with string data type.");
        }

        [TestMethod]
        public void CountTest()
        {
            list.Add(1);
            
            var case1 = list.Count;

            Assert.AreEqual(1, case1,
                "Returned value of DynamicList.Count doesn't correspond to actual added elements");
        }
    }
}