namespace WebsiteMonitor.Utility
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;        
    #endregion Usings
    /// <summary>
    /// Website to be monitored.
    /// </summary>
    internal class Website
    {
        /// <summary>
        /// Website ID.
        /// </summary>
        private readonly short websiteID;

        /// <summary>
        /// Website name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Website url to be checked.
        /// </summary>
        private readonly string url;

        /// <summary>
        /// Latest content.
        /// </summary>
        private string latestContent;

        /// <summary>
        /// Initialises a new instance of the <see cref="Website"/> class.
        /// </summary>
        /// <param name="websiteID">Website ID.</param>
        /// <param name="latestContent">Latest content saved.</param>
        /// <param name="name">Website name.</param>
        /// <param name="url">Website URL.</param>
        public Website(short websiteID, string latestContent, string name, string url)
        {
            this.websiteID = websiteID;
            this.name = name;
            this.url = url;
            this.latestContent = latestContent;
        }

        /// <summary>
        /// Gets website ID.
        /// </summary>
        public short WebsiteID
        {
            get { return this.websiteID; }
        }

        /// <summary>
        /// Gets name
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }            
        }

        /// <summary>
        /// Gets url.
        /// </summary>
        public string Url
        {
            get
            {
                return this.url;
            }            
        }

        /// <summary>
        /// Gets latest content.
        /// </summary>
        public string LatestContent
        {
            get
            {
                return this.latestContent;
            }
        }

        /// <summary>
        /// Check whether the content of the url is changed since last time checked.
        /// </summary>
        /// <returns></returns>
        internal bool ChangedSinceLastCheck()
        {
            WebRequest request = WebRequest.Create(this.url);
            WebResponse response = request.GetResponse();
            
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));

            String currentContent = sr.ReadToEnd();

            if (this.latestContent != currentContent)
            {
                this.latestContent = currentContent;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
