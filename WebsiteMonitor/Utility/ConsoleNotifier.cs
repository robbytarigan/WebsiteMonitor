namespace WebsiteMonitor.Utility
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;    
    #endregion Usings
    /// <summary>
    /// Console Notifier.
    /// </summary>
    class ConsoleNotifier : INotifier
    {
        /// <summary>
        /// Send notification to Robby.
        /// </summary>
        /// <param name="websiteName">Website name.</param>
        /// <param name="message">Notification message to be sent.</param>
        void INotifier.SendNotification(string websiteName, string message)
        {
            Console.WriteLine(
@"Changes on {0} are below: 
{1}", websiteName, message);
        }
    }
}
