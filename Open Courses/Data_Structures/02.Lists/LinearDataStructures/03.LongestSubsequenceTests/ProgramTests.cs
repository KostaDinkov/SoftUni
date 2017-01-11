namespace _03.LongestSubsequence.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProgramTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"),
         TestMethod]
        public void FindLongestSequenceTest()
        {
            // NOTE the data.csv file contains sample test cases
            // To add new ones, follow the routine and do not save int UTF-8
            // Save in ANSI encoding.  
            // Arrange

            var input = this.TestContext.DataRow["input"].ToString().
                Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).
                Select(i => int.Parse(i)).ToList();
            var expected = this.TestContext.DataRow["output"].ToString();

            // Act
            var actual = string.Join(" ", LongestSequence.FindLongestSequence(input));

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}