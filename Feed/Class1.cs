using System;
using CodeHollow.FeedReader;



namespace Import
{

    // Notes
    // https://www.nuget.org/packages/CodeHollow.FeedReader/
    // https://github.com/codehollow/FeedReader
    // https://github.com/codehollow/FeedReader/blob/master/FeedReader.ConsoleSample/Program.cs

    public class Feed
    {
        private string FeedUrl { get; set; }
        private string FeedUrl { get; set; }

        public Feed(string url)
        {

            FeedUrl = url;
            
            var readerTask = FeedReader.ReadAsync(url);
            readerTask.ConfigureAwait(false);

        }

        private 

    }
}
