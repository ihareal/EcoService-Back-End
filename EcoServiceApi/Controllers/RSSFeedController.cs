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
    public class RssFeedController : ControllerBase
    {
        private readonly EcoServiceContext _context; 

        public RssFeedController(EcoServiceContext context)
        {
            _context = context;
        }

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
            var rssFeedData = (from x in xml.Descendants("item")
                               select new RSSFeed
                               {
                                   Title = ((string)x.Element("title")),
                                   Link = ((string)x.Element("link")),
                                   Description = ((string)x.Element("description")),
                                   PubDate = ((string)x.Element("pubDate"))
                               });

            //TODO: Get all news from the database and check existing news
            List<NewsDetail> existingListNews = _context.NewsDetails.ToList(); 

            List<NewsDetail> newsList = new List<NewsDetail>();
            foreach(var rss in rssFeedData.Where(r => !existingListNews.Any(en => en.Title.Equals(r.Title))))
            {
                newsList.Add(new NewsDetail
                {
                    Description = rss.Description,
                    Title = rss.Title,
                    Link = rss.Link,
                    Date = Convert.ToDateTime(rss.PubDate),
                });
            }

            _context.NewsDetails.AddRange(newsList);
            //TODO: Add list to database and SaveChanges
            _context.SaveChanges();
            return _context.NewsDetails.ToList();
        }
    }
}