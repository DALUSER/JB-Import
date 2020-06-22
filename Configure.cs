using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Import.Utility;

namespace Import
{
    public partial class Configure : Form
    {
        public Configure()
        {
            InitializeComponent();

            // Build a List of the querystring parameters 
            //var querystringParams = new[] {
            //    new { key = "q", value = AppSettings.RssQuery }
            //};

            // Format each querystring parameter, and ensure its value is encoded
            //var encodedQueryStringParams = querystringParams.Select(p => string.Format("{0}={1}", p.key, HttpUtility.UrlEncode(p.value)));
            // Construct a strongly-typed Uri, with the querystring parameters appended
            //url.Query = string.Join("&", encodedQueryStringParams);


            //txtUrl.Text = AppSettings.RssBaseUrl;


            // Build RSS Query URL
            UriBuilder url = new UriBuilder(AppSettings.RssBaseUrl);
            url.Port = -1;

            // Parameter key/value pairs   
            var queryStringParams = new List<KeyValuePair<string, string>>();
            queryStringParams.Add(new KeyValuePair<string, string>("q", AppSettings.RssQuery));
            queryStringParams.Add(new KeyValuePair<string, string>("l", AppSettings.RssLocation));
            queryStringParams.Add(new KeyValuePair<string, string>("radius", AppSettings.RssRadius.ToString()));

            // Format each querystring parameter, and ensure its value is encoded
            var encodedQueryStringParams = queryStringParams.Select(p => string.Format("{0}={1}", p.Key, HttpUtility.UrlEncode(p.Value)));
            // Construct a strongly-typed Uri, with the querystring parameters appended
            url.Query = string.Join("&", encodedQueryStringParams);

            // http://www.indeed.ca/rss?q=store+clerk&l=Oakville%2C+ON&radius=100&sort=date

            // Display Configuration
            txtUrl.Text = url.ToString();
            txtQuery.Text = AppSettings.RssQuery;
            cmbLocation.DataSource = AppSettings.RssLocations;
            cmbLocation.SelectedItem = AppSettings.RssLocation;
            cmbRadius.DataSource = AppSettings.RssRadii;
            cmbRadius.SelectedItem = AppSettings.RssRadius;

        }
    }
}
