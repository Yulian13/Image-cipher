using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace Photo_cipher.Parser
{
    interface IParser<T> where T : class
    {
        string ClassName { get; set; }

        string Teg { get; set; }

        T Parser(IHtmlDocument document);
    }
}
