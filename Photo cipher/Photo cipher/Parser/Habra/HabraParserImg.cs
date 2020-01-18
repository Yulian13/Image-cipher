using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;

namespace Photo_cipher.Parser.Habra
{
    class HabraParserImg : IParser<SimpleObjectImg>
    {
        const string Teg = "img";
        const string ClassName = "fit-horizontal";
        const string Attribut = "src";

        const string TegNamber = "span";
        const string ClassNamber = "num-pages";

        public SimpleObjectImg Parser(IHtmlDocument document)
        {
            var list = new List<string>();

            string linkImg = document.QuerySelectorAll(Teg).
                Where(ele => ele.ClassName == ClassName).FirstOrDefault().GetAttribute(Attribut);

            int number = Int32.Parse(document.QuerySelectorAll(TegNamber).
                Where(ele => ele.ClassName == ClassNamber).FirstOrDefault().TextContent);

            linkImg = linkImg.Remove(linkImg.LastIndexOf('/')+1);

            return new SimpleObjectImg(linkImg, number);
        }
    }

    class SimpleObjectImg
    {
        public string LinkImg;
        public int number;

        public SimpleObjectImg(string linkImg, int number)
        {
            LinkImg = linkImg;
            this.number = number;
        }
    }
}
