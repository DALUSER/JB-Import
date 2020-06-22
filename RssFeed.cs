using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeHollow.FeedReader;

namespace Import
{
    // Notes
    // https://www.nuget.org/packages/CodeHollow.FeedReader/
    // https://github.com/codehollow/FeedReader
    // https://github.com/codehollow/FeedReader/blob/master/FeedReader.ConsoleSample/Program.cs

    public class RssFeed
    {
        private string feedUrl { get; set; }

        public Task<Feed> readerTask; 
        
        public RssFeed(string url)
        {
            feedUrl = url;
            ReadTheFeed();
        }

        private void ReadTheFeed()
        {
            readerTask = FeedReader.ReadAsync(feedUrl);
            readerTask.ConfigureAwait(false);
        }

        public interface IRssQuery
        {
            UriBuilder rssQuery();
        }
        public class service : IRssQuery
        {
            public UriBuilder rssQuery()
            {
                UriBuilder url = new UriBuilder();
                return url;
            }
        }

        //public class client
        //{
        //    private IRssQuery _rssQuery;

        //    public UriBuilder run(IRssQuery serv)
        //    {
        //        this._rssQuery = serv;
        //        this._rssQuery.rssQuery;
        //    }
        //}
    }

}
