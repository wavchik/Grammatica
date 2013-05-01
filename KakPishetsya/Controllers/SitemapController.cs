using System;
using System.Collections.Generic;
using System.Web.Mvc;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;
using KakPishetsya.Common.Web;

namespace KakPishetsya.Controllers
{
    public class SitemapController : Controller
    {
        private readonly BaseRepository<Word> wordRepository;

        public SitemapController(BaseRepository<Word> wordRepository)
        {
            this.wordRepository = wordRepository;
        }

        //
        // GET: /Sitemap/
        public XmlSitemapResult Index()
        {
            var items = new List<ISitemapItem>();

            AddPages(items);

            AddEntries(items);

            return new XmlSitemapResult(items);
        }

        private void AddPages(List<ISitemapItem> items)
        {
            items.AddRange(
                new[]
                    {
                        new SitemapItem(
                            Url.Action("Index", "Home", null, this.Request.Url.Scheme),
                            null,
                            SitemapChangeFrequency.Daily),
                        new SitemapItem(
                            Url.Action("Words", "Home", null, this.Request.Url.Scheme),
                            null,
                            SitemapChangeFrequency.Monthly)
                    }
                );
        }

        private void AddEntries(List<ISitemapItem> items)
        {
            var words = wordRepository.All;

            foreach (var w in words)
            {
                items.Add(
                    new SitemapItem(
                        Url.Action("Index", "Word", new { smartname = w.SmartName }, this.Request.Url.Scheme),
                        w.DateModified ?? DateTime.UtcNow,
                        SitemapChangeFrequency.Weekly
                    )
                );
            }
        }
    }
}