using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using EcoServiceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSSFeedController : ControllerBase
    {
        /// <summary>
        /// GET api/RSSFeed
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetRSSFeed()
        {
            string feed = "http://econews.com.au/feed/";
            WebClient wclient = new WebClient();
            string RSSData = wclient.DownloadString(feed);

            XDocument xml = XDocument.Parse(RSSData);
            var child = xml.Descendants("item");
            var RSSFeedData = (from x in xml.Descendants("item")
                               select new RSSFeed
                               {
                                   Title = ((string)x.Element("title")),
                                   Link = ((string)x.Element("link")),
                                   Description = ((string)x.Element("description")),
                                   PubDate = ((string)x.Element("pubDate"))
                               });
            return RSSFeedData;
        }
    }
}