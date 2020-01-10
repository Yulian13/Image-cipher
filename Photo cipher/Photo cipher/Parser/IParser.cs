using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace Photo_cipher.Parser
{
    interface IParser<T> where T : class
    {
        T Parser(IHtmlDocument document);
    }
}
