namespace WebsiteMonitor.Utility
{
    #region Usings
    using System;    
    #endregion Usings
    /// <summary>
    /// Notifier contains methods to send notification.
    /// </summary>
    public interface INotifier
    {
        /// <summary>
        /// Send notification to Robby.
        /// </summary>
        /// <param name="websiteName">Website name.</param>
        /// <param name="message">Notification message to be sent.</param>
        void SendNotification(string websiteName, string message);
    }
}
