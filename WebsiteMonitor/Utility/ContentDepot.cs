namespace WebsiteMonitor.Utility
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;    
    #endregion Usings
    public class ContentDepot
    {
        /// <summary>
        /// Save the content to the specified path.
        /// </summary>
        /// <param name="path">Path where the content to be saved.</param>
        /// <param name="content">Content to be saved.</param>
        public void Save(string path, string content)    
        {            
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(content);
            }
        }

        /// <summary>
        /// Fetch content in the specified path.
        /// </summary>
        /// <param name="path">Path where the content to be saved.</param>
        /// <returns>Content fetched.</returns>
        public string Fetch(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
