using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TinyURL.Domain.Models;

namespace TinyURL.Application.util
{
    public class NumberGenerator
    {
        public static int generateNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
        public static async Task<bool> isURLValidAsync(Link link) 
        {
            var pattern = "(^http:\\/\\/|^https:\\/\\/)?(www\\.)?(.+)";
            if (Regex.IsMatch(link.OriginalURL, pattern))
            {
                var first_match = Regex.Match(link.OriginalURL, pattern);

                link.OriginalURL = "http://" + first_match.Groups[3].Value;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    HttpResponseMessage response = await client.GetAsync(link.OriginalURL);

                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
