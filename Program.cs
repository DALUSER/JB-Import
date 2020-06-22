using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Import.Utility;
using Microsoft.Extensions.Configuration;


namespace Import
{
    static class Program
    {

        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationSettings();
            Application.Run(new Import());
        }

        static void ApplicationSettings()
        {
            List<string> locations = new List<string>();
            List<int> radii = new List<int>();

            // Application configuration
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            // Import
            AppSettings.RssBaseUrl = Configuration.GetSection("Import")["RssBaseUrl"];
            AppSettings.RssQuery = Configuration.GetSection("Import")["RssQuery"];
            AppSettings.RssLocation = Configuration.GetSection("Import")["RssLocation"];
            var locationsSection = Configuration.GetSection("Import:RssLocations");
            foreach (var location in locationsSection.GetChildren())
            {
                locations.Add(location.Value);
            }
            AppSettings.RssLocations = locations;
            AppSettings.RssRadius = Convert.ToInt32(Configuration.GetSection("Import")["RssRadius"]);
            var radiiSection = Configuration.GetSection("Import:RssRadii");
            foreach (var radius in radiiSection.GetChildren())
            {
                radii.Add(Convert.ToInt32(radius.Value));
            }
            AppSettings.RssRadii = radii;
            AppSettings.RssSort = Configuration.GetSection("Import")["RssSort"];
            // Upload
            AppSettings.Name = Configuration.GetSection("Upload")["Name"];
            AppSettings.LogfileDir = Configuration.GetSection("Upload")["LogfileDirectory"];
            AppSettings.BulkUpload = Convert.ToBoolean(Configuration.GetSection("Upload")["BulkUpload"]);
            // Site
            AppSettings.WebApiBaseUrl = Configuration.GetSection("JBSite")["WebApiBaseUrl"];
        }
    }
}
