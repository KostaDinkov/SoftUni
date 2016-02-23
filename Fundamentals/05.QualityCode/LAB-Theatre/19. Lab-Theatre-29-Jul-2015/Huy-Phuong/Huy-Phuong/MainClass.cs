/*//////////////////////////////////////
     ///                                  ///
    ///   Author: Huy Phuong Nguyen,     ///
   ///   Qui Nhơn, Bình Định, Vietnam   ///
  ///   Email: huy_p_n@yahoo.vn        ///
 ///                                  ///
//////////////////////////////////////*/

namespace TheatreGuide
{
    using System.Globalization;
    using System.Threading;
    using Interfaces;
    using IO;
    

    internal class MainClass
    {
        public static IPerformanceDatabase DataBase = new PerformanceDatabase();

        protected static void Main()
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

            var theatreGuideEngine = new Engine(DataBase, new ConsoleInput(), new ConsoleOutput());
            theatreGuideEngine.Run();
        }
    }
}