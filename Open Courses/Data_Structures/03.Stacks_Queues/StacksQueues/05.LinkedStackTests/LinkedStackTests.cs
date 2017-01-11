namespace _05.LinkedStack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void PushPop_ShouldIncreaseDecreaseCount()
        {
            // Act
            var testStack = new LinkedStack<int>();

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
            var stack = new LinkedStack<int>();
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
            var testStack = new LinkedStack<int>();

            // Act
            testStack.Pop();
        }

        [TestMethod]
        public void PushPop_Capacity1_ShouldWorkCorrectly()
        {
            // Arrange
            var initialCapacity = 1;

            // Act
            var testStack = new LinkedStack<int>();

            // Assert
            Assert.AreEqual(0, testStack.Count);

            testStack.Push(1);
            Assert.AreEqual(1, testStack.Count);

            testStack.Push(2);
            Assert.AreEqual(2, testStack.Count);

            Assert.AreEqual(2, testStack.Pop());
            Assert.AreEqual(1, testStack.Count);

            Assert.AreEqual(1, testStack.Pop());
            Assert.AreEqual(0, testStack.Count);
        }

        [TestMethod]
        public void ToArray_ShouldReturnStackAsReversedArray()
        {
            // Arrange
            var expected = "7, -2, 5, 3";
            var testStack = new LinkedStack<int>();
            testStack.Push(3);
            testStack.Push(5);
            testStack.Push(-2);
            testStack.Push(7);

            // Act 
            var actual = string.Join(", ", testStack.ToArray());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToArray_EmptyStack_ShouldReturnEmptyArray()
        {
            // Arrange
            var expected = "";
            var testStack = new LinkedStack<DateTime>();

            // Act
            var actual = string.Join(",", testStack.ToArray());

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}