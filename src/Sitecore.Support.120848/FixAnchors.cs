using System;
using System.Text;
using Sitecore.Pipelines.RenderField;

namespace Sitecore.Support.Pipelines.RenderField
{
  public class FixAnchors
  {
    const string pattern="href=\"";

    public void Process(RenderFieldArgs args)
    {
      args.Result.FirstPart = Fix(args.Result.FirstPart);
      args.Result.LastPart = Fix(args.Result.LastPart);
    }         

    protected string Fix(string text)
    {
      if (!text.Contains(pattern)) return text;

      int index = 0;
      int lastIndex = 0;
      StringBuilder result = new StringBuilder();
      while ((index=text.IndexOf(pattern, lastIndex, StringComparison.Ordinal)) >= 0)
      {
        result.Append(text.Substring(lastIndex, index - lastIndex + pattern.Length));
        string url = text.Substring(index + pattern.Length, text.IndexOf("\"", index + pattern.Length + 1, StringComparison.Ordinal)-index-pattern.Length);
        url = FixUrl(url);
        result.Append(url);   
        lastIndex = index + pattern.Length + url.Length;
      }

      result.Append(text.Substring(lastIndex));

      return result.ToString();
    }

    private string FixUrl(string url)
    {
      var sharp = url.IndexOf("#");

      if (sharp < 0) return url;

      var querystring = url.IndexOf("?", sharp + 1);

      if (querystring < 0) querystring = url.IndexOf("&", sharp + 1);
      if (querystring < 0) return url;

      return url.Substring(0, sharp) + url.Substring(querystring) + url.Substring(sharp, querystring - sharp);
    }
  }
}