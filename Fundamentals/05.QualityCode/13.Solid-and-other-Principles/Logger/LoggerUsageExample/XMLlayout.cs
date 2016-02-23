namespace LoggerUsageExample
{
    using System;
    using System.Xml.Linq;
    using Logger.Appenders;
    using Logger.Layouts;

    internal class XmLlayout : ILayout
    {
        public string Format(EntryLevel eventLevel, string msg)
        {
            var unformattedXml =
                "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>" +
                "<log>" +
                $"<date>{DateTime.Now}</date>" +
                $"<level>{eventLevel}</level>" +
                $"<message>{msg}</message>" +
                "</log>";

            var formattedXml = XElement.Parse(unformattedXml).ToString();
            return formattedXml;
        }
    }
}