namespace WebsiteMonitor.Service
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WebsiteMonitor.Utility;
    using System.Reflection;
    using System.IO;    
    #endregion Usings
    /// <summary>
    /// Default implementation of Monitor service.
    /// </summary>
    public class MonitorService : WebsiteMonitor.Service.IMonitorService
    {
        /// <summary>
        /// Depot root path.
        /// </summary>
        private static readonly string DepotRootPath = string.Format("{0}\\depot", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        /// <summary>
        /// Change notifier.
        /// </summary>
        private readonly INotifier notifier;

        /// <summary>
        /// Initialises a new instance of the <see cref="MonitorService"/> class.
        /// </summary>
        /// <param name="notifier">Change notifier.</param>
        public MonitorService(INotifier notifier)
        {
            this.notifier = notifier;
        }

        /// <summary>
        /// Run service.
        /// </summary>
        public void Run()
        {
            ContentDepot contentDepot = new ContentDepot();            
            
            List<Website> websites = new List<Website>() {
                new Website( 1, contentDepot.Fetch(GetDepotPath( 1)), "John Donne Primary School", "http://www.johndonne.southwark.sch.uk/news/default.asp?pid=3&nid=2"),
                new Website( 2, contentDepot.Fetch(GetDepotPath( 2)), "Harris Primary Academy Peckham Park", "http://www.harrisprimarypeckhampark.org.uk/26/term-dates"),
                ////new Website( 3, contentDepot.Fetch(GetDepotPath( 3)), "Camelot Primary School", "http://www.camelot.southwark.sch.uk/#!dates-for-your-diary"),                
                new Website( 4, contentDepot.Fetch(GetDepotPath( 4)), "Harris Primary Free School Peckham", "http://www.harrisfreeschoolpeckham.org.uk/25/full-school-calendar"),
                new Website( 5, contentDepot.Fetch(GetDepotPath( 5)), "Southwark Free School", "http://www.southwarkfreeschool.com/Home"),
                new Website( 6, contentDepot.Fetch(GetDepotPath( 6)), "St Mary Magdalene Church of England Primary School", "http://www.smmsprimary.co.uk/news.asp"),
                ////new Website( 7, contentDepot.Fetch(GetDepotPath( 7)), "Pilgrims' Way Primary School", ""),
                new Website( 8, contentDepot.Fetch(GetDepotPath( 8)), "Oliver Goldsmith Primary School", "http://www.connectedup.com/olivergoldsmith/page19.html"),
                ////new Website( 9, contentDepot.Fetch(GetDepotPath( 9)), "Kender Primary School", ""),
                ////new Website(10, contentDepot.Fetch(GetDepotPath(10)), "Bellenden Primary School", ""),
                ////new Website(11, contentDepot.Fetch(GetDepotPath(11)), "Rye Oak School", "")
            };

            for (int i = 0; i < 2; i++)
            {
                foreach (Website s in websites)
                {
                    if (s.ChangedSinceLastCheck())
                    {
                        contentDepot.Save(GetDepotPath(s.WebsiteID), s.LatestContent);
                        this.notifier.SendNotification(s.Name, s.LatestContent);
                    }
                }
            }
        }

        /// <summary>
        /// Get depot path by website ID.
        /// </summary>
        /// <param name="websiteID">Website ID.</param>
        /// <returns>Depot path.</returns>
        private static string GetDepotPath(short websiteID)    
        {
            return string.Format("{0}\\{1:D2}.txt", DepotRootPath, websiteID);
        }
    }
}
