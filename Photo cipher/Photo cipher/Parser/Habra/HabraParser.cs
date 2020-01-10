using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_cipher.Parser.Habra
{
    class HabraParser : IParser<string[]>
    {
        public string ClassName { get; set; }

        public string Teg { get; set; }

        public HabraParser(string className, string teg)
        {
            ClassName = className;
            Teg = teg;
        }

        public string[] Parser(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll(Teg).Where(item => item.ClassName != null && item.ClassName.Contains(ClassName));

            foreach(var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray()  ;
        }
    }
}
