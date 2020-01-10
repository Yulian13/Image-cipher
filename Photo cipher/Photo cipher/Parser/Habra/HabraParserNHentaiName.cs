using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_cipher.Parser.Habra
{
    class HabraParserNHentaiName : IParser<string>
    {
        const string TegName = "h1";

        public string Parser(IHtmlDocument document)
        {
            return document.QuerySelectorAll(TegName).FirstOrDefault().TextContent;
        }
    }
}
