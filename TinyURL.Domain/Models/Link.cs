using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL.Domain.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string OriginalURL { get; set; }
        public int ShortCutURLCode { get; set; }
    }
}
