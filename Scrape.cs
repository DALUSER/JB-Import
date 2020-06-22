using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Web;


namespace Import
{
    // https://www.nuget.org/packages/HtmlAgilityPack/


    public class Scrape
    {

        HtmlNode node;
        HtmlNodeCollection nodes;
        UriBuilder url = new UriBuilder("https://www.indeed.ca/viewjob?jk=");

        public string title { get; set; }
        public string company { get; set; }
        public Boolean compaignCompany { get; set; } = false;
        public string description { get; set; }
        public string location { get; set; }
        public string jobType { get; set; }
        public string salary { get; set; }


        public Scrape(string jobId)
        {

            // Build a List of the querystring parameters 
            var querystringParams = new[] {
                new { key = "jk", value = jobId }
            };

            // Format each querystring parameter, and ensure its value is encoded
            var encodedQueryStringParams = querystringParams.Select(p => string.Format("{0}={1}", p.key, HttpUtility.UrlEncode(p.value)));
            // Construct a strongly-typed Uri, with the querystring parameters appended
            url.Query = string.Join("&", encodedQueryStringParams);

            // Get an HTML document from an Internet resource
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDocument = web.Load(url.Uri);
            HtmlNode documentNode = htmlDocument.DocumentNode;

            // Title 
            // Job Title is contained in an <h3> element with class name 'jobsearch-JobInfoHeader-title'
            node = documentNode.SelectSingleNode("//h3[contains(@class, 'jobsearch-JobInfoHeader-title')]");
            if (node != null)
            {
                title = node.InnerText;
            }

            // Company
            // Determine whether job posting is for a campaign company
            node = documentNode.SelectSingleNode("//a[contains(@href, 'campaignid')]");
            if (node == null)
            {
                node = documentNode.SelectSingleNode("//div[contains(@class, 'jobsearch-InlineCompanyRating')]");
                if (node != null)
                {
                    company = HttpUtility.HtmlDecode(node.InnerText);
                }
            }
            else
            {
                company = HttpUtility.HtmlDecode(node.InnerText);
                compaignCompany = true;
            }

            // Location
            // Job Type
            // Salary 
            // All three are located within a <div> with a specific class name 
            nodes = documentNode.SelectNodes("//div[contains(@class, 'jobsearch-JobMetadataHeader-itemWithIcon')]");
            if (nodes != null)
            {
                // Location, Job Type and Salary are all identified by a specific icon class in the <div>
                foreach (HtmlNode iconNode in nodes)
                {
                    if (iconNode.InnerHtml.ToString().Contains("IconFunctional--location"))
                    {
                        location = iconNode.InnerText;
                        continue;
                    }
                    if (iconNode.InnerHtml.ToString().Contains("IconFunctional--jobs"))
                    {
                        jobType = iconNode.InnerText;
                        continue;
                    }
                    if (iconNode.InnerHtml.ToString().Contains("IconFunctional--salary"))
                    {
                        salary = iconNode.InnerText;
                        continue;
                    }
                }
            }

        }


    }
}
