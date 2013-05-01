using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace KakPishetsya.Common.Web
{
    public class XmlSitemapResult : ActionResult
    {
        private readonly IEnumerable<ISitemapItem> _items;

        public XmlSitemapResult(IEnumerable<ISitemapItem> items)
        {
            _items = items;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            string encoding = context.HttpContext.Response.ContentEncoding.WebName;
            var sitemap = new XDocument(new XDeclaration("1.0", encoding, "yes"),
                 new XElement(ns + "urlset",
                      from item in _items
                      select CreateItemElement(ns, item)
                      )
                 );

            context.HttpContext.Response.ContentType = "text/xml";
            context.HttpContext.Response.Flush();
            context.HttpContext.Response.Write(sitemap.Declaration + sitemap.ToString());
        }

        private XElement CreateItemElement(XNamespace ns, ISitemapItem item)
        {
            var itemElement = new XElement(ns +"url", new XElement(ns + "loc", item.Url.ToLower()));

            if (item.LastModified.HasValue)
                itemElement.Add(new XElement(ns + "lastmod", item.LastModified.Value.ToString("yyyy-MM-dd")));

            if (item.ChangeFrequency.HasValue)
                itemElement.Add(new XElement(ns + "changefreq", item.ChangeFrequency.Value.ToString().ToLower()));

            if (item.Priority.HasValue)
                itemElement.Add(new XElement(ns + "priority", item.Priority.Value.ToString(CultureInfo.InvariantCulture)));

            return itemElement;
        }
    }
}