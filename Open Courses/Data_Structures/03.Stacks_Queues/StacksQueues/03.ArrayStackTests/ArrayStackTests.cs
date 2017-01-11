namespace _03.ArrayStack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void PushPop_ShouldIncreaseDecreaseCount()
        {
            // Act
            var testStack = new ArrayStack<int>();

            // Assert
            Assert.AreEqual(0, testStack.Count);

            // Act
            testStack.Push(1);

            // Assert
            Assert.AreEqual(1, testStack.Count);

            // Act
            testStack.Pop();

            // Assert
            Assert.AreEqual(0, testStack.Count);
        }

        [TestMethod]
        public void PushPop1000_ShouldWorkCorrectry()
        {
            // Arrange
            var stack = new ArrayStack<int>();
            var numberOfElements = 1000;

            // Act
            for (var i = 0; i < numberOfElements; i++)
            {
                stack.Push(i);
            }

            // Assert
            for (var i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(numberOfElements - i, stack.Count);
                var element = stack.Pop();
                Assert.AreEqual(numberOfElements - i - 1, element);
                Assert.AreEqual(numberOfElements - i - 1, stack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Pop_FromEmptyStack_ShouldThrow()
        {
            // Arrange
            var testStack = new ArrayStack<int>();

            // Act
            testStack.Pop();
        }

        [TestMethod]
        public void PushPop_Capacity1_ShouldWorkCorrectly()
        {
            // Arrange
            int initialCapacity = 1;

            // Act
            var testStack = new ArrayStack<int>(initialCapacity);
            
            // Assert
            Assert.AreEqual(0,testStack.Count);

            testStack.Push(1);
            Assert.AreEqual(1,testStack.Count);
            
            testStack.Push(2);
            Assert.AreEqual(2, testStack.Count);

            Assert.AreEqual(2, testStack.Pop());
            Assert.AreEqual(1,testStack.Count);

            Assert.AreEqual(1,testStack.Pop());
            Assert.AreEqual(0,testStack.Count);

        }

        [TestMethod]
        public void ToArray_ShouldReturnStackAsReversedArray()
        {
            // Arrange
            string expected = "7, -2, 5, 3";
            ArrayStack<int> testStack = new ArrayStack<int>();
            testStack.Push(3);
            testStack.Push(5);
            testStack.Push(-2);
            testStack.Push(7);

            // Act 
            string actual = string.Join(", ",testStack.ToArray());

            // Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void ToArray_EmptyStack_ShouldReturnEmptyArray()
        {
            // Arrange
            var expected = "";
            ArrayStack<DateTime> testStack = new ArrayStack<DateTime>();

            // Act
            var actual = string.Join(",", testStack.ToArray());

            // Assert
            Assert.AreEqual(expected,actual);

        }
    }
}