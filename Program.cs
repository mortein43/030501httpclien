using HtmlAgilityPack;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        string url = "https://obmin.chernivtsi.ua/";

        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load(url);

        var currencyBlocks = document.DocumentNode.SelectNodes("//li[@class='currencies__block']");

        if (currencyBlocks != null)
        {
            foreach (var block in currencyBlocks)
            {
                var currencyName = block.SelectSingleNode(".//a")?.InnerText;
                var buyRate = block.SelectSingleNode(".//div[@class='currencies__block-buy']/div[@class='currencies__block-num']")?.InnerText;
                var saleRate = block.SelectSingleNode(".//div[@class='currencies__block-sale']/div[@class='currencies__block-num']")?.InnerText;

                Console.WriteLine($"Назва валюти: {currencyName}");
                Console.WriteLine($"Курс купівлі: {buyRate}");
                Console.WriteLine($"Курс продажу: {saleRate}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Не вдалося знайти блоки з курсами валют.");
        }
    }
}
