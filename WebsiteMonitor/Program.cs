namespace WebsiteMonitor
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WebsiteMonitor.Utility;
    using WebsiteMonitor.Service;        
    #endregion Usings
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Website Monitor by RS Tarigan. All rights reserved.");
            
            RunMonitor();
            
            Console.WriteLine("Finish... Please press ENTER to EXIT.");
            Console.ReadLine();
        }

        /// <summary>
        /// Run monitor.
        /// </summary>
        private static void RunMonitor()
        {
            IMonitorService monitorService = new MonitorService(new ConsoleNotifier());
            monitorService.Run();
        }
    }
}
