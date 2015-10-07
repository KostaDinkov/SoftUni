using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01.BunkerBuster;

namespace BunkerBusterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RunMain()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("4 4{0}" +
                                                                        "100 100 20 100{0}"+
                                                                        "30 50 100 100{0}" +
                                                                        "100 50 100 100{0}"+
                                                                        "100 100 100 100{0}"+
                                                                        "1 1 ={0}"+
                                                                        "cease fire!{0}",
                    Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    Program.Main();

                    string expected = string.Format(
                        "Destroyed bunkers: 3{0}Damage done: 18.8 %{0}",
                        Environment.NewLine);
                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }
    }
}
