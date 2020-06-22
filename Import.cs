using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using WebApiClient.Models;
using WebApiClient;
using Import.Utility;
using Import.Factory;

namespace Import
{
    public partial class Import : Form
    {

        enum itemsColumn
        {
            Title = 0,
            Id = 1,
            Link = 2,           // Link to page
            LinkId = 3,         // Link parameter
            LinkTitle = 4,      // Link parameter
            LinkCompany = 5,    // Link parameter
            LinkLocation = 6,   // Link parameter
            Latitude = 7,
            Longitude = 8,
            Author = 9,
            Content = 10,
            Description = 11,
            PublishedDate = 12
        }
        enum titlesColumn
        {
            FeedItemTitle = 0,
            LinkParamTitle = 1,
            HtmlPageTitle = 2
        }
        enum companiesColumn
        {
            LinkParamCompany = 0,
            HtmlPageCompany = 1,
            CampaignCompany = 2
        }
        enum locationsColumn
        {
            LinkParamLocation = 0,
            HtmlPageLocation = 1,
            CampaignCompany = 2
        }

        public List<Job> jobs = new List<Job>();

        public Import()
        {
            InitializeComponent();


            //string feedUrl = "http://www.indeed.ca/rss?q=store+clerk&l=Oakville%2C+ON&radius=100&sort=date";

            string feedUrl = AppSettings.RssBaseUrl;
            NameValueCollection queryColl;

            jobs.Clear();

            string linkId = String.Empty;
            string linkTitle = String.Empty;
            string linkCompany = String.Empty;
            string linkLocation = String.Empty;
            string geoRssPoint = String.Empty;

            int index;

            System.Xml.Linq.XElement element;
            IEnumerable<System.Xml.Linq.XElement> elements;

            // Items Tab
            dgdItems.RowTemplate.Height = 20;
            dgdItems.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgdItems.Columns[(int)itemsColumn.Id].Visible = false;
            dgdItems.Columns[(int)itemsColumn.Link].Visible = false;
            dgdItems.Columns[(int)itemsColumn.Author].Visible = false;
            dgdItems.Columns[(int)itemsColumn.Content].Visible = false;

            // Titles Tab
            dgdTitles.RowTemplate.Height = 20;
            dgdTitles.AutoResizeColumns();
            dgdTitles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Companies Tab
            dgdCompanies.RowTemplate.Height = 20;
            dgdCompanies.AutoResizeColumns();
            dgdCompanies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Locations Tab
            dgdLocations.RowTemplate.Height = 20;
            dgdLocations.AutoResizeColumns();
            dgdLocations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            RssFeed feed = new RssFeed(feedUrl);
            foreach (var item in feed.readerTask.Result.Items)
            {
                // Parse the query string to get relevant parameters
                var uri = new Uri(item.Link);
                queryColl = HttpUtility.ParseQueryString(uri.Query);
                linkTitle = queryColl.Get("t");
                linkLocation = queryColl.Get("l");
                linkCompany = queryColl.Get("c");
                linkId = queryColl.Get("jk");

                // Scrape the page for relevant information
                Scrape scrape = new Scrape(linkId);

                // Locate the geo co-ordinates from the XML element
                element = item.SpecificItem.Element;
                if (element != null)
                {
                    if (element.HasElements)
                    {
                        elements = element.Descendants();
                        foreach (System.Xml.Linq.XElement el in elements)
                        {
                            if (el.Name.ToString().Contains("georss"))
                            {
                                geoRssPoint = el.Value;
                            }
                        }
                    }
                }
                // Split the GEO coordinates into latitude and longitude
                string[] geoCoords = geoRssPoint.Split(' ');
                double geoLatitude = Convert.ToDouble(geoCoords[0]);
                double geoLongitude = Convert.ToDouble(geoCoords[1]);

                // Items Tab
                index = dgdItems.Rows.Add();
                dgdItems.Rows[index].Cells[(int)itemsColumn.Title].Value = item.Title;
                dgdItems.Rows[index].Cells[(int)itemsColumn.Id].Value = item.Id;
                dgdItems.Rows[index].Cells[(int)itemsColumn.Link].Value = item.Link;
                dgdItems.Rows[index].Cells[(int)itemsColumn.LinkId].Value = linkId;
                dgdItems.Rows[index].Cells[(int)itemsColumn.LinkTitle].Value = linkTitle;
                dgdItems.Rows[index].Cells[(int)itemsColumn.LinkCompany].Value = linkCompany;
                dgdItems.Rows[index].Cells[(int)itemsColumn.LinkLocation].Value = linkLocation;
                dgdItems.Rows[index].Cells[(int)itemsColumn.Latitude].Value = geoLatitude;
                dgdItems.Rows[index].Cells[(int)itemsColumn.Longitude].Value = geoLongitude;
                dgdItems.Rows[index].Cells[(int)itemsColumn.Description].Value = item.Description;

                // Titles Tab
                index = dgdTitles.Rows.Add();
                dgdTitles.Rows[index].Cells[(int)titlesColumn.FeedItemTitle].Value = item.Title;
                dgdTitles.Rows[index].Cells[(int)titlesColumn.LinkParamTitle].Value = linkTitle;
                dgdTitles.Rows[index].Cells[(int)titlesColumn.HtmlPageTitle].Value = scrape.title;

                // Companies Tab
                index = dgdCompanies.Rows.Add();
                dgdCompanies.Rows[index].Cells[(int)companiesColumn.LinkParamCompany].Value = linkCompany;
                dgdCompanies.Rows[index].Cells[(int)companiesColumn.HtmlPageCompany].Value = scrape.company;
                if (scrape.compaignCompany)
                {
                    dgdCompanies.Rows[index].Cells[(int)companiesColumn.CampaignCompany].Value = "Yes";
                }

                // Locations Tab
                index = dgdLocations.Rows.Add();
                dgdLocations.Rows[index].Cells[(int)locationsColumn.LinkParamLocation].Value = linkLocation;
                dgdLocations.Rows[index].Cells[(int)locationsColumn.HtmlPageLocation].Value = scrape.location;
                if (scrape.compaignCompany)
                {
                    dgdLocations.Rows[index].Cells[(int)locationsColumn.CampaignCompany].Value = "Yes";
                }

                // Add item to collection for push if required
                jobs.Add
                    (
                        new Job
                        {
                            Title = item.Title,
                            Company = linkCompany,
                            HtmlDescription = item.Description
                        }
                    );

                // Add relevant items to DataGridView 
                //dgdItems.Rows.Add(
                //    item.Title,
                //    item.Id,
                //    item.Link,
                //    linkId,
                //    linkTitle,
                //    scrape.title,
                //    linkCompany,
                //    linkLocation,
                //    geoLatitude,
                //    geoLongitude,
                //    item.Author,
                //    item.Content,
                //    item.Description,
                //    item.PublishingDate
                //);

            }

        }

        private void toolStripPush_Click(object sender, EventArgs e)
        {
            if (jobs.Any())
            {
                UploadJobs();
            }
        }
        private void toolStripConfigure_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            Configure config = new Configure();
            dr = config.ShowDialog();
            if (dr == DialogResult.OK)
                MessageBox.Show("User clicked OK button");
            else if (dr == DialogResult.Cancel)
                MessageBox.Show("User clicked Cancel button");
        }


        public void UploadJobs()
        {
            foreach (Job j in jobs)
            {
                if (AppSettings.BulkUpload == true)
                {
                    RunAsync(j).GetAwaiter().GetResult();
                }
                else
                {
                    //RunAsync(j).GetAwaiter().GetResult();
                    RunAsync(j).GetAwaiter();
                }
            }
        }

        public async Task RunAsync(Job job)
        {
            //var response = await ApiClientFactory.Instance.AddJob(job);
            var response = await ApiClientFactory.Instance.AddJob(job);
            string abc = "sdfsdf";
        }

    }
}
