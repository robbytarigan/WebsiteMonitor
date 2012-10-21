namespace WebsiteMonitor.Utility
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Mail;    
    #endregion Usings
    /// <summary>
    /// Notifier contains methods to send notification.
    /// </summary>
    internal class Notifier : WebsiteMonitor.Utility.INotifier
    {
        /// <summary>
        /// Send notification to Robby.
        /// </summary>
        /// <param name="websiteName">Website name.</param>
        /// <param name="message">Notification message to be sent.</param>
        void INotifier.SendNotification(string websiteName, string message)
        {
            SmtpClient mailClient = new SmtpClient();

            mailClient.Send(
                "sqladmin@wcgplc.co.uk",
                "robby.tarigan@wcgplc.co.uk",
                string.Format("Content Changes on {0}", websiteName),
                message);
        }
    }
}
