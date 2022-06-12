using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Web;
using WebScraping;

string html = "<div class=\"item\" rating=\"3\" data-pdid=\"5426\">\r\n        <figure>\r\n            <a href=\"https://www.100percent.co.nz/Product/WCM7000WD/Electrolux-700L-Chest-Freezer\">\r\n                <img alt=\"Electrolux 700L Chest Freezer &amp; Filter\" src=\"/productimages/thumb/1/5426_5731_4009.jpg\" data-alternate-image=\"/productimages/thumb/2/5426_5731_4010.jpg\" class=\"mouseover- set\" />\r\n                <span class=\"overlay top-horizontal\">\r\n                    <span class=\"sold-out\">\r\n                        <img alt=\"Sold Out\" src=\"/Images/Overlay/overlay_1_2_1.png\" />\r\n                    </span>\r\n                </span>\r\n            </a>\r\n        </figure>\r\n        <div class=\"item-detail\">\r\n            <h4>\r\n                <a href=\"https://www.100percent.co.nz/Product/WCM7000WD/Electrolux-700L-Chest-Freezer\">Electrolux 700L Chest Freezer</a>\r\n            </h4>\r\n            <div class=\"pricing\" itemprop=\"offers\" itemscope=\"itemscope\" itemtype=\"http://schema.org/Offer\">\r\n                <meta itemprop=\"priceCurrency\" content=\"NZD\" />\r\n                <p class=\"price\">\r\n                    <span class=\"price-display formatted\" itemprop=\"price\">\r\n                        <span style=\"display: none\">$2,099.00</span>\r\n                        $\r\n                        <span class=\"dollars over500\">2,099</span>\r\n                        <span class=\"cents zero\">.00</span>\r\n                    </span>\r\n                </p>\r\n            </div>\r\n            <p class=\"style-number\">WCM7000WD</p>\r\n            <p class=\"offer\">\r\n                <a href=\"https://www.100percent.co.nz/Product/WCM7000WD/Electrolux-700L-Chest-Freezer\">\r\n                    <span style=\"color: #cc0000\">WCM7000WD</span>\r\n                </a>\r\n            </p>\r\n            <div class=\"item-asset\">\r\n                <!--.-->\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"item\" rating=\"3.6\" data-pdid=\"5862\">\r\n        <figure>\r\n            <a href=\"https://www.100percent.co.nz/Product/E203S/Electrolux-Anti-Odour-\r\n        Vacuum-Bags\"><img alt=\"Electrolux Anti-Odour Vacuum Bags\"\r\n                    src=\"/productimages/thumb/1/5862_6182_4541.jpg\" /></a>\r\n        </figure>\r\n        <div class=\"item-detail\">\r\n            <h4>\r\n                <a href=\"https://www.100percent.co.nz/Product/E203S/Electrolux-Anti-Odour-\r\n        Vacuum-Bags\">Electrolux Anti-Odour Vacuum Bags</a>\r\n            </h4>\r\n            <div class=\"pricing\" itemprop=\"offers\" itemscope=\"itemscope\" itemtype=\"http://schema.org/Offer\">\r\n                <meta itemprop=\"priceCurrency\" content=\"NZD\" />\r\n                <p class=\"price\">\r\n                    <span class=\"price-display formatted\" itemprop=\"price\"><span\r\n                            style=\"display: none\">$22.99</span>$<span class=\"dollars\">22</span><span\r\n                            class=\"cents\">.99</span></span>\r\n                </p>\r\n            </div>\r\n            <p class=\"style-number\">E203S</p>\r\n            <p class=\"offer\">\r\n                <a href=\"https://www.100percent.co.nz/Product/E203S/Electrolux-Anti-Odour-Vacuum-Bags\"><span\r\n                        style=\"color: #cc0000\">E203S</span></a>\r\n            </p>\r\n            <div class=\"item-asset\">\r\n                <!--.-->\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"item\" rating=\"8.4\" data-pdid=\"4599\">\r\n        <figure>\r\n            <a href=\"https://www.100percent.co.nz/Product/USK11ANZ/Electrolux-UltraFlex-\r\n        Starter-Kit\"><img alt=\"Electrolux UltraFlex Starter &#91; Kit &#93; \"\r\n                    src=\"/productimages/thumb/1/4599_4843_2928.jpg\" /></a>\r\n        </figure>\r\n        <div class=\"item-detail\">\r\n            <h4>\r\n                <a href=\"https://www.100percent.co.nz/Product/USK11ANZ/Electrolux-UltraFlex-\r\n        Starter-Kit\">Electrolux UltraFlex &#64; Starter Kit</a>\r\n            </h4>\r\n            <div class=\"pricing\" itemprop=\"offers\" itemscope=\"itemscope\" itemtype=\"http://schema.org/Offer\">\r\n                <meta itemprop=\"priceCurrency\" content=\"NZD\" />\r\n                <p class=\"price\">\r\n                    <span class=\"price-display formatted\" itemprop=\"price\"><span\r\n                            style=\"display: none\">$44.99</span>$<span class=\"dollars\">44</span><span\r\n                            class=\"cents\">.99</span></span>\r\n                </p>\r\n            </div>\r\n            <p class=\"style-number\">USK11ANZ</p>\r\n            <p class=\"offer\">\r\n                <a href=\"https://www.100percent.co.nz/Product/USK11ANZ/Electrolux-UltraFlex-\r\n        Starter-Kit\"><span style=\"color: #cc0000\">USK11ANZ</span></a>\r\n            </p>\r\n            <div class=\"item-asset\">\r\n                <!--.-->\r\n            </div>\r\n        </div>\r\n    </div>";

var parsedData = ParseHtml(html);

string json = SerializeObjects(parsedData);

Console.WriteLine(json);

string SerializeObjects(IEnumerable<Product> products)
{
    string savePath = "../../../products.json";
    string json = JsonConvert.SerializeObject(products, Formatting.Indented);

    File.WriteAllText(savePath, json);

    return json;
}

IEnumerable<Product> ParseHtml(string html)
{
    HtmlDocument htmlDocument = new HtmlDocument();
    htmlDocument.LoadHtml(html);

    var items = htmlDocument.DocumentNode
        .Descendants("div")
        .Where(node => node.HasClass("item"))
        .ToList();

    List<Product> products = new();

    foreach (var item in items)
    {
        string? name = GetProductName(item);
        decimal? price = GetPrice(item);
        decimal? rating = GetRating(item);

        Product vehicle = new Product
        {
            Name = HttpUtility.HtmlDecode(name),
            Price = price.ToString(),
            Rating = rating,
        };

        products.Add(vehicle);
    }

    return products;
}

string? GetProductName(HtmlNode node)
{
    try
    {
        string productName = node
            .Descendants("img")
            .First().Attributes["alt"].Value;

        return productName;
    }
    catch (Exception ex)
    {
        return null;
    }
}

decimal? GetPrice(HtmlNode node)
{
    try
    {
        var priceAsString = node
        .Descendants("p")
        .Where(node => node.HasClass("price"))
        .First()
        .Descendants("span")
        .First()
        .Descendants("span")
        .First()
        .GetDirectInnerText();

        var formatPrice = string
            .Join(" ", priceAsString.Split(","))
            .Replace("$", "");

        return decimal.Parse(formatPrice);
    }
    catch (Exception ex)
    {
        return null;
    }

}

decimal? GetRating(HtmlNode node)
{
    try
    {
        string ratingAsString = node.Attributes
            .First(attribute => attribute.Name == "rating").Value;

        return decimal.Parse(ratingAsString);
    }
    catch (Exception ex)
    {
        return null;
    }
}