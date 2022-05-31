using System.Text;
using System.Text.RegularExpressions;

namespace JackStore.Common
{
    public static class StringExtension
    {
        public static string ToSnakeCase(this string textoOriginal)
        {
            var ret = "";

            if (!string.IsNullOrEmpty(textoOriginal))
            {
                var inicioUnderscores = Regex.Match(textoOriginal, @"^_+");
                ret = inicioUnderscores + Regex.Replace(textoOriginal, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
            }

            return ret;
        }

        public static string GetSlug(this string str)
        {
            str = str.RemoveAccent().ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"\s+"," ").Trim();
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-");

            return str;
        }

        public static string RemoveAccent(this string str)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(str);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}