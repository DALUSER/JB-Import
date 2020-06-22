using System;
using System.Collections.Generic;
using System.Text;

namespace Import.Utility
{
    public static class AppSettings
    {

        // JB Import
        public static string RssBaseUrl { get; set; }
        public static string RssQuery { get; set; }
        public static string RssLocation { get; set; }
        public static List<string> RssLocations { get; set; }
        public static int RssRadius { get; set; }
        public static List<int> RssRadii { get; set; }
        public static string RssSort { get; set; }

        // Uplaod process
        public static string Name { get; set; }
        public static string LogfileDir { get; set; }
        public static bool BulkUpload { get; set; }

        // JB Site
        public static string WebApiBaseUrl { get; set; }


    }


}
