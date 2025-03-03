using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL.Domain.Models
{
    public class LinkViewModel
    {
        public Link? Link { get; set; }
        public List<Link>? Links { get; set; }
    }
}
